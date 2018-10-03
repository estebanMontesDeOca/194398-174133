using System;
using MatchesOfSports.DataAccess;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MatchesOfSports.WebApi.Tests
{
    public class RepositoryShould
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void FailToCreatIfContextIsNull()
        {
            MatchesOfSportsContext context = null;

            RepositoryOf<Sport> repository = new RepositoryOf<Sport>(context);
        
        }
 
    }
}   