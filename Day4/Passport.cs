using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Day4
{
    class Passport
    {
        public string Byr { get; set; }
        public string Iyr { get; set; }
        public string Eyr { get; set; }
        public string Hgt { get; set; }
        public string Hcl { get; set; }
        public string Ecl { get; set; }
        public string Pid { get; set; }
        public string Cid { get; set; }

        public bool ValidateAllFields(Passport passport)
        {
            if (ValidByr(Int32.Parse(passport.Byr)) != true)
                return false;
            else if (ValidIyr(Int32.Parse(passport.Iyr)) != true)
                return false;
            else if (ValidEyr(Int32.Parse(passport.Eyr)) != true)
                return false;
            else if (ValidHgt(passport.Hgt) != true)
                return false;
            else if (ValidateHcl(passport.Hcl) != true)
                return false;
            else if (ValidEcl(passport.Ecl) != true)
                return false;
            else if (ValidatePid(passport.Pid) != true)
                return false;
            return true;
        }

        private bool ValidByr(int byr)
        {
            bool returnValue = false;
            if (byr >= 1920 && byr <= 2002)
                returnValue = true;
            return returnValue;
        }

        private bool ValidIyr(int iyr)
        {
            bool returnValue = false;
            if (iyr >= 2010 && iyr <= 2020)
                returnValue = true;
            return returnValue;
        }

        private bool ValidEyr(int eyr)
        {
            bool returnValue = false;
            if (eyr >= 2020 && eyr <= 2030)
                returnValue = true;
            return returnValue;
        }

        private bool ValidHgt(string hgt)
        {
            int hgtAsInt = ConvertHgtToInt(hgt);
            if (hgtIsCm(hgt) && hgtAsInt >= 150 && hgtAsInt <= 193)
                return true;
            else if (hgtIsIn(hgt) && hgtAsInt >= 59 && hgtAsInt <= 76)
                return true;
            else
                return false;


        }
        private bool ValidateHcl(string hcl)
        {
            bool returnValue = false;
            Regex regex = new Regex("#{1}[a-f0-9]{6}");
            if (regex.IsMatch(hcl))
                returnValue = true;
            return returnValue;
        }

        private bool ValidEcl(string ecl)
        {
            string[] eyeColors = { "amb", "blu", "brn", "gry", "grn", "hzl", "oth" };
            bool returnValue = false;
            foreach (var color in eyeColors)
            {
                if (color == ecl)
                    returnValue = true;
            }
            return returnValue;
        }

        private bool ValidatePid(string pid)
        {
            bool resturnValue = true;
            if (WrongLengthOfPid(pid))
                return false;
            else
            {
                foreach (var myChar in pid)
                {
                    if (!Char.IsDigit(myChar))
                        resturnValue = false;
                }
                return resturnValue;
            }
        }

        private bool WrongLengthOfPid(string pid)
        {
            bool returnValue = false;
            if (pid.Length != 9)
                returnValue = true;
            return returnValue;
        }

        private int ConvertHgtToInt(string hgt)
        {
            string height = "";
            foreach (var myChar in hgt)
            {
                if (Char.IsDigit(myChar))
                    height += myChar;
            }
            return Int32.Parse(height);
        }

        private bool hgtIsCm(string hgt)
        {
            bool returnValue = false;
            Regex regex = new Regex("[c][m]$");
            if (regex.IsMatch(hgt))
                returnValue = true;
            return returnValue;
        }
        private bool hgtIsIn(string hgt)
        {
            bool returnValue = false;
            Regex regex = new Regex("[i][n]$");
            if (regex.IsMatch(hgt))
                returnValue = true;
            return returnValue;
        }
    }




}
