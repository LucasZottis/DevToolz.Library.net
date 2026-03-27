namespace DevToolz.Library.Crypt.Interfaces;

public interface ICryptAlgorithm
{
    string Encrypt( string value, string key );
    string Decrypt( string value, string key );
}
