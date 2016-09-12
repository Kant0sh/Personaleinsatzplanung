using Personaleinsatzplanung.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personaleinsatzplanung.SQL
{
    public static class SqlUtility
    {
        public const string All = "*";

        public static string Equal(string Field, object EqualTo)
        {
            return Field + "='" + EqualTo.ToString() + "'";
        }

        public static string AppendWithCommas(params string[] strings)
        {
            string s = "";
            for (int i = 0; i < strings.Length; i++)
            {
                s = s + strings[i];
                if (i != strings.Length - 1) s = s + ", ";
            }
            return s;
        }

        public static string[] ToArrayFromCommas(string commas)
        {
            string[] strings = commas.Split(',');
            for(int i = 0; i < strings.Length; i++)
            {
                strings[i] = strings[i].Trim();
            }
            return strings;
        }

        public static string GenerateSets(string[] fields)
        {
            string s = string.Empty;
            for(int i = 0; i < fields.Length; i++)
            {
                s = s + fields[i] + "=?" + fields[i] + ", ";
            }
            s = s.Substring(0, s.Length-2);
            return s;
        }

        public async static Task<List<Mitarbeiter>> LoadAllMitarbeiterAsync(ISqlHandler Sql, string Fields)
        {
            SqlDataSet Data = await Sql.SelectAsync(Mitarbeiter.Table, Fields);
            List<Mitarbeiter> loadedMitarbeiterList = new List<Mitarbeiter>();
            for (int i = 0; i < Data.DataRowCount; i++)
            {
                Mitarbeiter mitarbeiter = new Mitarbeiter();
                for (int j = 0; j < Data.FieldCount; j++)
                {
                    string f = Data.FieldNames[j];
                    object d = Data.GetFieldData(f)[i];
                    if (f == Mitarbeiter.FieldId) mitarbeiter.Id = (int)d;
                    else if (f == Mitarbeiter.FieldKennung) mitarbeiter.Kennung = (string)d;
                    else if (f == Mitarbeiter.FieldName) mitarbeiter.Name = (string)d;
                    else if (f == Mitarbeiter.FieldVorname) mitarbeiter.Vorname = (string)d;
                    else if (f == Mitarbeiter.FieldFähigkeiten) mitarbeiter.Fähigkeiten = (string)d;
                    else if (f == Mitarbeiter.FieldSchicht) mitarbeiter.Schicht = await LoadSchichtAsync(Sql, (int)d);
                    else if (f == Mitarbeiter.FieldTelefon) mitarbeiter.AddRufnummer(new Rufnummer((string)d, RufnummerTyp.FestnetzPrivat));
                    else if (f == Mitarbeiter.FieldMobil) mitarbeiter.AddRufnummer(new Rufnummer((string)d, RufnummerTyp.MobilDienst));
                    else if (f == Mitarbeiter.FieldTelefonIntern) mitarbeiter.AddRufnummer(new Rufnummer((string)d, RufnummerTyp.FestnetzIntern));
                    else if (f == Mitarbeiter.FieldFaxIntern) mitarbeiter.AddRufnummer(new Rufnummer((string)d, RufnummerTyp.FaxIntern));
                    else if (f == Mitarbeiter.FieldEMail) mitarbeiter.AddEmail((string)d);
                }
                loadedMitarbeiterList.Add(mitarbeiter);
            }
            return loadedMitarbeiterList;
        }

        public static async Task<Schicht> LoadSchichtAsync(ISqlHandler Sql, int Id)
        {
            SqlDataSet Data = await Sql.SelectAllWhereAsync(Schicht.Table, Equal(Schicht.FieldId, Id));
            Schicht schicht = new Schicht();
            for (int j = 0; j < Data.FieldCount; j++)
            {
                string f = Data.FieldNames[j];
                object d = Data.GetFieldData(f)[0];
                if (f == Schicht.FieldId) schicht.Id = (int)d;
                else if (f == Schicht.FieldBezeichnung) schicht.Bezeichnung = (string)d;
            }
            return schicht;
        }
    }
}
