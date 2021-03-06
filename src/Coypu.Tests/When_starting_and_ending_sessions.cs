﻿using System;
using Coypu.Tests.TestDoubles;
using NUnit.Framework;

namespace Coypu.Tests
{
    [TestFixture]
    public class When_starting_and_ending_sessions
    {
        [SetUp]
        public void SetUp()
        {
            Configuration.Driver = typeof (FakeDriver);
        }

        [TearDown]
        public void TearDown()
        {
            Browser.EndSession();
        }

        [Test]
        public void A_session_is_always_available()
        {
            Assert.That(Browser.Session, Is.TypeOf(typeof (Session)));

            Browser.EndSession();

            Assert.That(Browser.Session, Is.TypeOf(typeof (Session)));
        }

        [Test]
        public void After_end_a_new_session_is_available()
        {
            var firstSession = Browser.Session;
            Assert.That(firstSession, Is.TypeOf(typeof(Session)));

            Browser.EndSession();

            Assert.That(Browser.Session, Is.Not.SameAs(firstSession));
        }

        [Test]
        public void End_ignores_a_null_session()
        {
            Browser.EndSession();
        }

        [Test]
        public void After_disposing_the_session_a_new_session_is_available()
        {
            Session firstSession;
            using (var session = Browser.Session)
            {
                firstSession = session;
            }
            Assert.That(Browser.Session, Is.Not.SameAs(firstSession));
        }

        [Test]
        public void A_session_gets_its_driver_from_config()
        {
            Configuration.Driver = typeof (FakeDriver);
            Assert.That(Browser.Session.Driver, Is.TypeOf(typeof (FakeDriver)));

            Browser.EndSession();

            Configuration.Driver = typeof (StubDriver);
            Assert.That(Browser.Session.Driver, Is.TypeOf(typeof (StubDriver)));
        }

        [Test]
        public void Session_exposes_native_driver_if_you_really_need_it()
        {
            Configuration.Driver = typeof (FakeDriver);
            Assert.That(Browser.Session.Native, Is.EqualTo("Native driver on fake driver"));

            Browser.EndSession();

            Configuration.Driver = typeof (StubDriver);
            Assert.That(Browser.Session.Native, Is.EqualTo("Native driver on stub driver"));
        }

    }
}