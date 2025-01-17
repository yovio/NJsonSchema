﻿using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NJsonSchema.Tests.Generation
{
    [TestClass]
    public class SchemaGenerationTests
    {
        [TestMethod]
        public void When_generating_schema_with_object_property_then_additional_properties_are_not_allowed()
        {
            //// Arrange

            //// Act
            var schema = JsonSchema4.FromType<Foo>();
            var schemaData = schema.ToJson();

            //// Assert
            Assert.AreEqual(false, schema.Properties["Bar"].AllowAdditionalProperties);
        }

        [TestMethod]
        public void When_generating_schema_with_dictionary_property_then_it_must_allow_additional_properties()
        {
            //// Arrange
            
            //// Act
            var schema = JsonSchema4.FromType<Foo>();
            var schemaData = schema.ToJson();

            //// Assert
            Assert.AreEqual(true, schema.Properties["Dictionary"].AllowAdditionalProperties);
            Assert.AreEqual(JsonObjectType.String, schema.Properties["Dictionary"].AdditionalPropertiesSchema.Type);
        }
    }

    public class Foo
    {
        public Dictionary<string, string> Dictionary { get; set; }
        
        public Bar Bar { get; set; } 
    }

    public class Bar
    {
        public string Name { get; set; }
    }
}
