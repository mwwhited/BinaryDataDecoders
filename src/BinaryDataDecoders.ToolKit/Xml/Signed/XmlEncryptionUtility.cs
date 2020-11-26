//using System;
//using System.Collections.Generic;
//using System.Text;
//using System.Xml;

//namespace BinaryDataDecoders.ToolKit.Xml.Signed
//{
//    // https://snipt.net/Wolfwyrd/encryption-utilities/
//    public static class XmlEncryptionUtility
//    {
//        #region Private Constants
//        /// <summary>Index of the private key header</summary>
//        private const int magic_priv_idx = 0x08;
//        /// <summary>Index of the public key header</summary>
//        private const int magic_pub_idx = 0x14;
//        /// <summary>Header size</summary>
//        private const int magic_size = 4;

//        /// <summary>Block size used in encrypt/decrypt actions</summary>
//        public static readonly int BLOCK_SIZE = 64;
//        #endregion

//        #region Public Methods

//        #region Get RSA From SNK File
//        /// <summary>
//        /// Returns RSA object from *.snk key file.
//        /// </summary>
//        /// <param name="path">Path to snk file.</param>
//        /// <returns>RSACryptoServiceProvider</returns>
//        public static RSACryptoServiceProvider GetRSAFromSnkFile(string path)
//        {
//            Contract.Requires(!string.IsNullOrEmpty(path));
//            Contract.Ensures(Contract.Result<RSACryptoServiceProvider>() != null);
//            var snkBytes = XmlEncryptionUtility.GetFileBytes(path);
//            var rsa = XmlEncryptionUtility.GetRSAFromSnkBytes(snkBytes);
//            return rsa;
//        }
//        #endregion

//        #region Get Public Key From Assembly
//        /// <summary>
//        /// Retrieves an RSA public key from a signed assembly
//        /// </summary>
//        /// <param name="assembly">Signed assembly to retrieve the key from</param>
//        /// <returns>RSA Crypto Service Provider initialized with the key from the assembly</returns>
//        public static RSACryptoServiceProvider GetPublicKeyFromAssembly(Assembly assembly)
//        {
//            Contract.Requires(assembly != null, "Assembly may not be null");
//            Contract.Ensures(Contract.Result<RSACryptoServiceProvider>() != null);

//            var pubkey = assembly.GetName().GetPublicKey();
//            if (pubkey.Length <= 1)
//                throw new InvalidOperationException("No public key in assembly.");

//            var rsaParams = XmlEncryptionUtility.GetRSAParameters(pubkey);
//            var rsa = new RSACryptoServiceProvider();
//            rsa.ImportParameters(rsaParams);

//            return rsa;
//        }
//        #endregion

//        #region Get RSA Parameters
//        /// <summary>
//        /// Returns RSAParameters from byte[]. Example to get rsa public key from assembly:
//        /// byte[] pubkey = Assembly.GetExecutingAssembly().GetName().GetPublicKey();
//        /// RSAParameters p = SnkUtil.GetRSAParameters(pubkey);
//        /// </summary>
//        /// <param name="keypair">keypair loaded as a byte array</param>
//        /// <returns>Parameters for initializing an RSA Crypto Provider with the passed key information</returns>
//        public static RSAParameters GetRSAParameters(byte[] keyBytes)
//        {
//            Contract.Requires(keyBytes != null);
//            Contract.Requires(keyBytes.Length > 1);

//            var ret = new RSAParameters();

//            var pubonly = XmlEncryptionUtility.SnkBufIsPubLength(keyBytes);

//            if ((pubonly) && (!XmlEncryptionUtility.CheckRSA1(keyBytes)))
//                return ret;

//            if ((!pubonly) && (!XmlEncryptionUtility.CheckRSA2(keyBytes)))
//                return ret;

//            int magic_idx = pubonly ? magic_pub_idx : magic_priv_idx;

//            // Bitlen is stored here, but note this class is only set up for 1024 bit length keys
//            int bitlen_idx = magic_idx + magic_size;
//            int bitlen_size = 4;  // DWORD

//            // Exponent, In read file, will usually be { 1, 0, 1, 0 } or 65537
//            int exp_idx = bitlen_idx + bitlen_size;
//            int exp_size = 4;


//            //BYTE modulus[rsapubkey.bitlen/8]; == MOD; Size 128
//            int mod_idx = exp_idx + exp_size;
//            int mod_size = 128;

//            //BYTE prime1[rsapubkey.bitlen/16]; == P; Size 64
//            int p_idx = mod_idx + mod_size;
//            int p_size = 64;

//            //BYTE prime2[rsapubkey.bitlen/16]; == Q; Size 64
//            int q_idx = p_idx + p_size;
//            int q_size = 64;

//            //BYTE exponent1[rsapubkey.bitlen/16]; == DP; Size 64
//            int dp_idx = q_idx + q_size;
//            int dp_size = 64;

//            //BYTE exponent2[rsapubkey.bitlen/16]; == DQ; Size 64
//            int dq_idx = dp_idx + dp_size;
//            int dq_size = 64;

//            //BYTE coefficient[rsapubkey.bitlen/16]; == InverseQ; Size 64
//            int invq_idx = dq_idx + dq_size;
//            int invq_size = 64;

//            //BYTE privateExponent[rsapubkey.bitlen/8]; == D; Size 128
//            int d_idx = invq_idx + invq_size;
//            int d_size = 128;


//            // Figure public params, Must reverse order (little vs. big endian issue)
//            ret.Exponent = XmlEncryptionUtility.BlockCopy(keyBytes, exp_idx, exp_size);
//            Array.Reverse(ret.Exponent);
//            ret.Modulus = XmlEncryptionUtility.BlockCopy(keyBytes, mod_idx, mod_size);
//            Array.Reverse(ret.Modulus);

//            if (pubonly) return ret;

//            // Figure private params
//            // Must reverse order (little vs. big endian issue)
//            ret.P = BlockCopy(keyBytes, p_idx, p_size);
//            Array.Reverse(ret.P);

//            ret.Q = BlockCopy(keyBytes, q_idx, q_size);
//            Array.Reverse(ret.Q);

//            ret.DP = BlockCopy(keyBytes, dp_idx, dp_size);
//            Array.Reverse(ret.DP);

//            ret.DQ = BlockCopy(keyBytes, dq_idx, dq_size);
//            Array.Reverse(ret.DQ);

//            ret.InverseQ = BlockCopy(keyBytes, invq_idx, invq_size);
//            Array.Reverse(ret.InverseQ);

//            ret.D = BlockCopy(keyBytes, d_idx, d_size);
//            Array.Reverse(ret.D);

//            return ret;
//        }
//        #endregion

//        #region Asymmetric Encrypt
//        /// <summary>
//        /// Encrypts a given byte array using the public key lifted from the passed assembly
//        /// </summary>
//        /// <param name="assembly">Assembly to retrieve the public key from</param>
//        /// <param name="dataToEncrypt">Data to be encrypted with the passed public key</param>
//        /// <returns>Encrypted data as a byte array, null if either argument is null</returns>
//        public static byte[] AsymmetricEncrypt(Assembly assembly, byte[] dataToEncrypt)
//        {
//            Contract.Requires(assembly != null);
//            Contract.Requires(dataToEncrypt != null);
//            Contract.Ensures(Contract.Result<byte[]>() != null);
//            //Load the keys from the assembly
//            var cipher = XmlEncryptionUtility.GetPublicKeyFromAssembly(assembly);

//            //Prepare variables used in encryption
//            int blockSize = XmlEncryptionUtility.BLOCK_SIZE, index = 0, bytesLeft = dataToEncrypt.Length, totalBytes = 0;

//            //Ensure that the total bytes is a multiple of 128, the final encrypted content block will 
//            //be padded to this length in bytes
//            if ((bytesLeft * 2) % 128 != 0)
//                totalBytes = (bytesLeft * 2) + (128 - ((bytesLeft * 2) % 128));
//            else
//                totalBytes = bytesLeft * 2;

//            //Create the buffer for encrypted data
//            using (var memEncryptedTextbuffer = new MemoryStream(totalBytes))
//            {
//                byte[] block = null;
//                byte[] encryptedBlock = null;

//                //Split the serialized data into smaller blocks for encryption
//                while (bytesLeft > 0)
//                {
//                    //If the blocksize is too large, set it to the required amount
//                    if (bytesLeft < blockSize)
//                        blockSize = bytesLeft;

//                    //Get a block from the serialized license data and encrypt it
//                    block = XmlEncryptionUtility.BlockCopy(dataToEncrypt, index, blockSize);
//                    encryptedBlock = cipher.Encrypt(block, false);
//                    memEncryptedTextbuffer.Write(encryptedBlock, 0, encryptedBlock.Length);

//                    //Update position and size tracking
//                    index += blockSize;
//                    bytesLeft -= blockSize;
//                    block = null;
//                    encryptedBlock = null;
//                }
//                cipher.Clear();

//                //Dump the encrypted data to the caller
//                memEncryptedTextbuffer.Position = 0;
//                return memEncryptedTextbuffer.ToArray();
//            }
//        }
//        #endregion

//        #region Asymmetric Decrypt

//        /// <summary>
//        /// Asymmetrically decrypts a given byte array using the keys from a strong named keyfile
//        /// passed as a byte array
//        /// </summary>
//        /// <param name="encryptedData">Data to be decrypted</param>
//        /// <param name="snkFileContent">Content of the keyfile</param>
//        /// <returns>Byte array of decrypted data</returns>
//        public static byte[] AsymmetricDecrypt(byte[] encryptedData, byte[] snkFileContent)
//        {
//            Contract.Requires(encryptedData != null);
//            Contract.Requires(snkFileContent != null);
//            Contract.Requires(snkFileContent.Length > 1);
//            var cipher = XmlEncryptionUtility.GetRSAFromSnkBytes(snkFileContent);
//            return DoAsymmetricDecrypt(cipher, encryptedData);
//        }

//        /// <summary>
//        /// Asymmetrically decrypts a given byte array using the keys taken from the provided
//        /// strong name key file path
//        /// </summary>
//        /// <param name="encryptedData">Data to be decrypted</param>
//        /// <param name="snkFilePath">Path to the key file</param>
//        /// <returns>Byte array of decrypted data</returns>
//        public static byte[] AsymmetricDecrypt(byte[] encryptedData, string snkFilePath)
//        {
//            Contract.Requires(encryptedData != null);
//            Contract.Requires(!string.IsNullOrEmpty(snkFilePath));
//            //Prepare the cipher
//            RSACryptoServiceProvider cipher = XmlEncryptionUtility.GetRSAFromSnkFile(snkFilePath);
//            return DoAsymmetricDecrypt(cipher, encryptedData);
//        }
//        #endregion

//        #region Symmetric Decrypt
//        /// <summary>
//        /// Decrypts the passed data using the RijnDael algorithm using the supplied key and initialisation vector
//        /// </summary>
//        /// <param name="itemToDencrypt">Data to be decrypted</param>
//        /// <param name="key">Key used to perform the decryption</param>
//        /// <param name="iv">Initialisation vector supplied to the algorithm</param>
//        /// <returns>Byte array of decrypted data</returns>
//        public static byte[] SymmetricDecrypt(byte[] itemToDecrypt, byte[] key, byte[] iv)
//        {
//            //If null is passed as an argument return an empty string
//            if (itemToDecrypt == null || key == null || iv == null)
//                return null;

//            //Dump the encrypted string to a buffer ready for decryption
//            using (MemoryStream msEncryptedText = new MemoryStream(itemToDecrypt, 0, itemToDecrypt.Length, false))
//            {
//                //Create and prepare the cypher
//                RijndaelManaged cipher = new RijndaelManaged();
//                cipher.BlockSize = 128;
//                cipher.Padding = PaddingMode.PKCS7;

//                //Create the decryption stream and apply it to the passed data
//                using (CryptoStream csOut = new CryptoStream(msEncryptedText, cipher.CreateDecryptor(key, iv), CryptoStreamMode.Read))
//                {
//                    byte[] decryptedData = new byte[itemToDecrypt.Length];
//                    int stringSize = csOut.Read(decryptedData, 0, itemToDecrypt.Length);
//                    csOut.Close();
//                    cipher.Clear();

//                    //Trim the excess empty elements from the array and convert back to a string
//                    byte[] trimmedData = new byte[stringSize];
//                    Array.Copy(decryptedData, trimmedData, stringSize);

//                    return trimmedData;
//                }
//            }
//        }
//        #endregion

//        #region Symmetric Encrypt
//        /// <summary>
//        /// Encrypts the passed data using the RijnDael algorithm
//        /// </summary>
//        /// <param name="itemToEncrypt">Item to be encrypted</param>
//        /// <param name="key">Key supplied for the encryption</param>
//        /// <param name="iv">Initialisation Vector for the algorithm</param>
//        /// <returns>Byte array of encrypted data</returns>
//        public static byte[] SymmetricEncrypt(byte[] itemToEncrypt, byte[] key, byte[] iv)
//        {
//            //If null is passed as an argument return an empty string
//            if (itemToEncrypt == null || key == null || iv == null)
//                return null;

//            //Create the cypher, encrypt the string and dump to a buffer in memory
//            RijndaelManaged cipher = new RijndaelManaged();
//            cipher.BlockSize = 128;
//            cipher.Padding = PaddingMode.PKCS7;

//            //Write the data to a memory buffer
//            using (MemoryStream msEncryptedTextBuffer = new MemoryStream())
//            using (CryptoStream csOut = new CryptoStream(msEncryptedTextBuffer, cipher.CreateEncryptor(key, iv), CryptoStreamMode.Write))
//            {
//                csOut.Write(itemToEncrypt, 0, itemToEncrypt.Length);
//                csOut.Flush();
//                csOut.FlushFinalBlock();

//                //Read the encrypted data from the buffer and close all streams
//                msEncryptedTextBuffer.Position = 0;
//                byte[] data = msEncryptedTextBuffer.ToArray();
//                msEncryptedTextBuffer.Close();
//                csOut.Close();
//                cipher.Clear();

//                return data;
//            }
//        }
//        #endregion

//        #region Block Copy
//        /// <summary>
//        /// Copies a subset of a byte array to a new byte array
//        /// </summary>
//        /// <param name="source">Source array to copy the content from</param>
//        /// <param name="idx">Starting point in the array to copy from</param>
//        /// <param name="size">Number of bytes to copy</param>
//        /// <returns>
//        /// New array containing the copied subset, null if the required size would overshoot the bounds 
//        /// of the array
//        /// </returns>
//        public static byte[] BlockCopy(byte[] source, int startAt, int size)
//        {
//            if ((source == null) || (source.Length < (startAt + size)))
//                return null;

//            byte[] ret = new byte[size];
//            Buffer.BlockCopy(source, startAt, ret, 0, size);
//            return ret;
//        }
//        #endregion

//        #endregion

//        #region Private Methods

//        #region Get File Bytes
//        /// <summary>
//        /// Reads a file as an array of bytes
//        /// </summary>
//        /// <param name="path">Path to the file to read</param>
//        /// <returns>File contents as an array of bytes</returns>
//        private static byte[] GetFileBytes(string path)
//        {
//            Contract.Requires(!string.IsNullOrEmpty(path));
//            Contract.Ensures(Contract.Result<byte[]>() != null);

//            using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
//            using (BinaryReader br = new BinaryReader(fs))
//            {
//                byte[] bytes = br.ReadBytes((int)fs.Length);
//                return bytes;
//            }
//        }
//        #endregion

//        #region Get RSA From SNK Bytes
//        /// <summary>
//        /// Creates an RSA Provider using the passed keypair byte array
//        /// </summary>
//        /// <param name="snkBytes">Keypair as byte array</param>
//        /// <returns>RSA Provider initialised with the passed keypair</returns>
//        private static RSACryptoServiceProvider GetRSAFromSnkBytes(byte[] snkBytes)
//        {
//            if (snkBytes == null)
//                throw new ArgumentNullException("snkBytes");

//            RSAParameters param = GetRSAParameters(snkBytes);

//            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
//            rsa.ImportParameters(param);
//            return rsa;
//        }
//        #endregion

//        #region Snk Buffer Is Public Length
//        /// <summary>
//        /// Returns true if buffer length is public key size.
//        /// </summary>
//        /// <param name="keypair">Keypair as bytes</param>
//        /// <returns>True if the buffer length is public key size, otherwise false</returns>
//        private static bool SnkBufIsPubLength(byte[] keypair)
//        {
//            if (keypair == null)
//                return false;
//            return (keypair.Length == 160);
//        }
//        #endregion

//        #region Check RSA1
//        /// <summary>
//        /// Check that RSA1 is in header (public key only).
//        /// </summary>
//        /// <param name="keypair">Keypair to check</param>
//        /// <returns>True if the header contains RSA1, otherwise false</returns>
//        private static bool CheckRSA1(byte[] pubkey)
//        {
//            // Check that RSA1 is in header.
//            //                             R     S     A     1
//            byte[] check = new byte[] { 0x52, 0x53, 0x41, 0x31 };
//            return CheckMagic(pubkey, check, magic_pub_idx);
//        }
//        #endregion

//        #region Check RSA2
//        /// <summary>
//        /// Check that RSA2 is in header (public and private key).
//        /// </summary>
//        /// <param name="keypair">Keypair to check</param>
//        /// <returns>True if RSA2 is in the header, otherwise, false</returns>
//        private static bool CheckRSA2(byte[] pubkey)
//        {
//            // Check that RSA2 is in header.
//            //                             R     S     A     2
//            byte[] check = new byte[] { 0x52, 0x53, 0x41, 0x32 };
//            return CheckMagic(pubkey, check, magic_priv_idx);
//        }
//        #endregion

//        #region Check Magic
//        /// <summary>
//        /// Checks the "Magic" bytes that form the header for RSA definition
//        /// </summary>
//        /// <param name="keypair">Keypair to check</param>
//        /// <param name="check">Bytes that we are trying to match</param>
//        /// <param name="idx">Index of the header</param>
//        /// <returns>True if the keypair contains the check bytes, otherwise false</returns>
//        private static bool CheckMagic(byte[] keypair, byte[] check, int idx)
//        {
//            Contract.Requires(keypair != null);
//            Contract.Requires(keypair.Length >= magic_size);
//            Contract.Requires(check != null);
//            Contract.Requires(check.Length >= magic_size);
//            var magic = XmlEncryptionUtility.BlockCopy(keypair, idx, magic_size);
//            if (magic == null)
//                return false;

//            for (int i = 0; i < magic_size; i++)
//            {
//                if (check[i] != magic[i])
//                    return false;
//            }

//            return true;
//        }
//        #endregion

//        #region Do Asymmetric Decrypt
//        /// <summary>
//        /// Performs an asymmetric decyption of passed data
//        /// </summary>
//        /// <param name="cipher">Cipher used to perform the decrypt</param>
//        /// <param name="encryptedData">Data to decrypt</param>
//        /// <returns>Byte array containing decrypted data</returns>
//        private static byte[] DoAsymmetricDecrypt(RSACryptoServiceProvider cipher, byte[] encryptedData)
//        {
//            //Prepare block detail
//            int blockSize = XmlEncryptionUtility.BLOCK_SIZE * 2, index = 0, bytesLeft = encryptedData.Length;

//            using (MemoryStream memDecryptedTextbuffer = new MemoryStream(bytesLeft / 2))
//            {
//                byte[] block = null;
//                byte[] decryptedBlock = null;

//                //Split the serialized data into smaller blocks for processing
//                while (bytesLeft > 0)
//                {
//                    //If the blocksize is too large, set it to the required amount
//                    if (bytesLeft < blockSize)
//                        blockSize = bytesLeft;

//                    //Get a block from the encrypted data
//                    block = XmlEncryptionUtility.BlockCopy(encryptedData, index, blockSize);
//                    decryptedBlock = cipher.Decrypt(block, false);
//                    memDecryptedTextbuffer.Write(decryptedBlock, 0, decryptedBlock.Length);

//                    //Update position and size tracking
//                    index += blockSize;
//                    bytesLeft -= blockSize;
//                    block = null;
//                    decryptedBlock = null;
//                }
//                cipher.Clear();

//                //Dump the encrypted data to the caller
//                memDecryptedTextbuffer.Position = 0;
//                return memDecryptedTextbuffer.ToArray();
//            }
//        }
//        #endregion

//        #endregion

//        public static void SignXmlFile(string unsignedXmlPath, string signedXmlOutputPath, AsymmetricAlgorithm key)
//        {
//            Contract.Requires(!string.IsNullOrEmpty(unsignedXmlPath));
//            Contract.Requires(!string.IsNullOrEmpty(signedXmlOutputPath));

//            var unsignedXml = new XmlDocument();
//            unsignedXml.PreserveWhitespace = false;
//            unsignedXml.Load(unsignedXmlPath);

//            // Create a reference to be signed. Blank == Everything
//            var emptyReference = new Reference { Uri = "" };

//            // Add an enveloped transformation to the reference.
//            var envelope = new XmlDsigEnvelopedSignatureTransform();
//            emptyReference.AddTransform(envelope);

//            var signedXml = new SignedXml(unsignedXml) { SigningKey = key };
//            signedXml.AddReference(emptyReference);
//            signedXml.ComputeSignature();

//            var digitalSignature = signedXml.GetXml();
//            unsignedXml.DocumentElement.AppendChild(unsignedXml.ImportNode(digitalSignature, true));

//            unsignedXml.Save(signedXmlOutputPath);
//        }

//        public static bool VerifyXmlFile(Stream signedXmlStream, AsymmetricAlgorithm key)
//        {
//            Contract.Requires(signedXmlStream != null);
//            Contract.Requires(key != null);

//            var signedXml = new XmlDocument();
//            signedXml.PreserveWhitespace = false;
//            signedXml.Load(signedXmlStream);

//            var nsm = new XmlNamespaceManager(new NameTable());
//            nsm.AddNamespace("dsig", SignedXml.XmlDsigNamespaceUrl);

//            var signatureGenerator = new SignedXml(signedXml);
//            var signatureNode = signedXml.SelectSingleNode("//dsig:Signature", nsm);
//            signatureGenerator.LoadXml((XmlElement)signatureNode);

//            return signatureGenerator.CheckSignature(key);
//        }

//        public static bool VerifyXmlFile(string signedXmlPath, AsymmetricAlgorithm key)
//        {
//            Contract.Requires(!string.IsNullOrEmpty(signedXmlPath));
//            Contract.Requires(key != null);

//            var signedXml = new XmlDocument();
//            signedXml.PreserveWhitespace = false;
//            signedXml.Load(signedXmlPath);

//            var nsm = new XmlNamespaceManager(new NameTable());
//            nsm.AddNamespace("dsig", SignedXml.XmlDsigNamespaceUrl);

//            var signatureGenerator = new SignedXml(signedXml);
//            var signatureNode = signedXml.SelectSingleNode("//dsig:Signature", nsm);
//            signatureGenerator.LoadXml((XmlElement)signatureNode);

//            return signatureGenerator.CheckSignature(key);
//        }
//    }
//}
