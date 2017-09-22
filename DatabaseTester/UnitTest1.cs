﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Battleships.net.DataBase;
using Battleships.net.DataBase.Builder;
using NHibernate;
using Battleships.net.DataBase.Setup;
using Battleships.net.Services;
[assembly: log4net.Config.XmlConfigurator(Watch = true)]

namespace DatabaseTester
{
    [TestClass]
    public class UnitTest1
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        [TestMethod]
        public void TestCreateDataBase()
        {
            Builder builder = new Builder();
            builder.BuildDataBase();
            
        }
        [TestMethod]
        public void TestCreateGrid()
        {
            var session = DbService.OpenSession();
            Setup setup = new Setup(session);
            setup.SetupGrid(8, 8);
            DbService.CloseSession(session);
            //setup.Cleanup();
        }

        [TestMethod]
        public void TestCreateGame()
        {
            var session = DbService.OpenSession();
            Setup setup = new Setup(session);
            var game = setup.CreateGame("Anton", "Pelle");
            log.Debug(session);
            DbService.CloseSession(session);
        }

        [TestMethod]
        public void TestCreatePerson()
        {
            var session = DbService.OpenSession();
            Setup setup = new Setup(session);
            setup.AddAndOrLoadUser("Test");
            log.Debug(session);
            DbService.CloseSession(session);
        }

        [TestMethod]
        public void TestCleanUp()
        {
            var session = DbService.OpenSession();
            Setup setup = new Setup(session);
            setup.Cleanup();
            DbService.CloseSession(session);
        }
    }
}
