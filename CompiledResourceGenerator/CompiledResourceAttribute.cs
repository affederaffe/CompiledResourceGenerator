using System;


namespace CompiledResourceGenerator
{
    [AttributeUsage(AttributeTargets.Method)]
    public class CompiledResourceAttribute : Attribute
    {
        public CompiledResourceAttribute(string path)
        {
            Path = path;
        }

        public string Path { get; }
    }
}
