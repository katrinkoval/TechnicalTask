namespace TechnicalTask.Models
{
    public class NodeModel
    {
        public required string Name { get; set; }

        public required string Value { get; set; }

        public List<NodeModel>? Children { get; set; }
    }
}
