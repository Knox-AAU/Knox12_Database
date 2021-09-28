﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.OpenApi.Any;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using NJsonSchema.Validation;
using JsonSchema = NJsonSchema.JsonSchema;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace KnoxDatabaseLayer3.JsonUtility
{
    public sealed class SampleJsonExample
    {
        private const string JsonFileName = "sampleWordCount.json";
        private const string JsonSchemaFileName = "wordCounterSchema.json";
        
        public void Run()
        {
            string directory = AppDomain.CurrentDomain.BaseDirectory;
            string jsonString = File.ReadAllText($"{directory}/{JsonFileName}");
            string jsonSchema = File.ReadAllText($"{directory}/{JsonSchemaFileName}");
            
            JsonSerializerOptions options = new()
            {
                PropertyNameCaseInsensitive = false
            };
            
            Task.Run(() => Test(jsonSchema, jsonString));
        }

        private async void Test(string jsonSchema, string jsonString)
        {
            var schema = await JsonSchema.FromJsonAsync(jsonSchema);
            var errors = schema.Validate(jsonString);

            foreach (ValidationError error in errors)
            {
                Console.WriteLine(error);
            }
        }
    }
}