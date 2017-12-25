﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLibrary.BusinessObjects.BaseObjects
{
    public class EnumLibrary
    {
        public enum Gender
        {
            Undefined,
            Male,
            Female
        }

        public enum MaritalStatus
        {
            Undefined,
            Single,
            Maried,
            Divorced,
            Widowed
        }

        public enum Religion
        {
            Undefined,
            Buddha,
            Hindu,
            Islam,
            Kristen,
            Katolik,
            KongHuCu
        }

        public enum IdentityType
        {
            Undefined,
            KTP,
            SIM,
            Passpor
        }
    }
}
