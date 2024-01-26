namespace TechnicalTask.Models
{
    public class NodeModel
    {
        public required string Name { get; set; }

        public List<NodeModel>? Children { get; set; }
    }
}
