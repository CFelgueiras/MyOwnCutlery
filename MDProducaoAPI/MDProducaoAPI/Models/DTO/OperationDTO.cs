namespace MDProducaoAPI.Models.DTO
{
    public class OperationDTO
    {
        public long OperationId { get; set; }
        public string Name { get; set; }

        public string ToolName { get; set; }

        public string OperationTool { get; set; }

        public int OperationTime { get; set; }

        public double PreparationTime { get; set; }

        public OperationDTO(string OperationTool)
        {
            OperationTool = ToolName + OperationTool;
        }
    }
}