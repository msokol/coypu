﻿using NSpec;
using NUnit.Framework;

namespace Coypu.Drivers.Tests
{
    internal class When_finding_sections : DriverSpecs
    {
        internal override void Specs()
        {
            describe["finding sections by header text"] = () =>
            {
                it["finds by h1 text"] = () =>
                {
                    driver.FindSection("Section One h1").Id.should_be("sectionOne");
                    driver.FindSection("Section Two h1").Id.should_be("sectionTwo");
                };
                it["finds by h2 text"] = () =>
                {
                    driver.FindSection("Section One h2").Id.should_be("sectionOne");
                    driver.FindSection("Section Two h2").Id.should_be("sectionTwo");
                };
                it["finds by h3 text"] = () =>
                {
                    driver.FindSection("Section One h3").Id.should_be("sectionOne");
                    driver.FindSection("Section Two h3").Id.should_be("sectionTwo");
                };
                it["finds by h6 text"] = () =>
                {
                    driver.FindSection("Section One h6").Id.should_be("sectionOne");
                    driver.FindSection("Section Two h6").Id.should_be("sectionTwo");
                };
                it["finds section by id"] = () =>
                {
                    driver.FindSection("sectionOne").Id.should_be("sectionOne");
                    driver.FindSection("sectionTwo").Id.should_be("sectionTwo");
                };

               
            };
            
            it["only finds div and section"] = () =>
            {
                Assert.Throws<MissingHtmlException>(() => driver.FindSection("scope1TextInputFieldId"));
                Assert.Throws<MissingHtmlException>(() => driver.FindSection("fieldsetScope2"));
            };
        }
    }

}