namespace DevToolz.Library.Encryption.Interfaces;

public interface ICryptAlgorithm
{
    string Encrypt( string value, string key );
    string Decrypt( string value, string key );
}
