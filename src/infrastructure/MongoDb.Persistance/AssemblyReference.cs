﻿using System.Reflection;

namespace MongoDb.Persistence;


public static class AssemblyReference
{
    public static readonly Assembly Assembly = typeof(AssemblyReference).Assembly;
}
