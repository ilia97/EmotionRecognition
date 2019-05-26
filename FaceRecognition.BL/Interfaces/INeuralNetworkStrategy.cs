namespace FaceRecognition.BL.Interfaces
{
    public interface INeuralNetworkStrategy
    {
        string Recognize(byte[] image);
    }
}
