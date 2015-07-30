namespace AutoMapperExtenderTests
{
    public class A
    {
        public string Prop1 { get; set; }
        public string Prop2 { get; set; }
        public string Prop3 { get; set; }
    }

    public class B
    {
        public A PropA { get; set; }
    }

    public class C
    {
        public string Prop1 { get; set; }
        public string Prop2 { get; set; }
    }
}