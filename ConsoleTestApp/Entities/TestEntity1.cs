﻿namespace ConsoleTestApp.Entities
{
    public class TestEntity1: IEntity, IHasName
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
