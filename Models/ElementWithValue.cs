﻿using System;

namespace algebra_de_conjuntos.Models
{
    class ElementWithValue
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public long Value { get; set; }

        public ElementWithValue(Element e)
        {
            Id = IdGenerator.GenerateId();
            Name = e.Name;
            Value = Int64.Parse(e.Value);
        }

        public ElementWithValue(string nome, long value)
        {
            Id = IdGenerator.GenerateId();
            Name = nome;
            Value = value;
        }
    }
}
