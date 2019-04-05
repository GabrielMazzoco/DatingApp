using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests.Helpers
{
    public class BaseTest
    {

        public void VerificarCamposNulos(Object dto)
        {
            foreach (var prop in dto.GetType().GetProperties())
            {
                object value = prop.GetValue(dto);
                Assert.IsNotNull(value);
            }
        }
    }
}
