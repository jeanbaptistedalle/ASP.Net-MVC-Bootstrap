using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestApp2.Models;

namespace TestApp2.DAL
{
    public class _DAL
    {
        public TestApp2Entities GetContext()
        {
            return new TestApp2Entities();
        }
    }
}