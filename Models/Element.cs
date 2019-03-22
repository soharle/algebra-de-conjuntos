namespace algebra_de_conjuntos.Models
{
    public class Element
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }

        public Element()
        {
            this.Id = IdGenerator.GenerateId();
        }

        public Element(string value)
        {
            this.Id = IdGenerator.GenerateId();
            this.Value = value;
        }
        public Element(string name, string value)
        {
            this.Id = IdGenerator.GenerateId();
            this.Name = name;
            this.Value = value;
        }

    }

}
