using Amazon.Runtime;
using Amazon.S3;
using Amazon.S3.Model;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Wlniao;

namespace EBA_API_CORE.Classes
{
    public class AmazonS3
    {
        public string AccessKeyIDS3 { get; set; }
        public string SecretAccessKeyS3 { get; set; }
        public string RegionS3 { get; set; }
        public string BucketS3 { get; set; }



        public AmazonS3(string AccessKeyID, string SecretAccessKey, string Region, string Bucket)
        {
            AccessKeyIDS3 = AccessKeyID;
            SecretAccessKeyS3 = SecretAccessKey;
            RegionS3 = Region;
            BucketS3 = Bucket;
        }

        private Amazon.RegionEndpoint GetRegion(string Region)
        {
            switch (Region)
            {
                case "USEast1": return Amazon.RegionEndpoint.USEast1;
                //case "CACentral1": return Amazon.RegionEndpoint.CACentral1;
                //case "CNNorthWest1": return Amazon.RegionEndpoint.CNNorthWest1;
                case "CNNorth1": return Amazon.RegionEndpoint.CNNorth1;
                case "USGovCloudWest1": return Amazon.RegionEndpoint.USGovCloudWest1;
                //case "USGovCloudEast1": return Amazon.RegionEndpoint.USGovCloudEast1;
                case "SAEast1": return Amazon.RegionEndpoint.SAEast1;
                case "APSoutheast2": return Amazon.RegionEndpoint.APSoutheast2;
                //case "APSouth1": return Amazon.RegionEndpoint.APSouth1;
               // case "APNortheast3": return Amazon.RegionEndpoint.APNortheast3;
                case "APNortheast2": return Amazon.RegionEndpoint.APNortheast2;
                case "APSoutheast1": return Amazon.RegionEndpoint.APSoutheast1;
                //case "APEast1": return Amazon.RegionEndpoint.APEast1;
                //case "USEast2": return Amazon.RegionEndpoint.USEast2;
                case "APNortheast1": return Amazon.RegionEndpoint.APNortheast1;
                case "USWest2": return Amazon.RegionEndpoint.USWest2;
                //case "EUNorth1": return Amazon.RegionEndpoint.EUNorth1;
                case "USWest1": return Amazon.RegionEndpoint.USWest1;
                //case "EUWest2": return Amazon.RegionEndpoint.EUWest2;
                //case "EUWest3": return Amazon.RegionEndpoint.EUWest3;
                case "EUCentral1": return Amazon.RegionEndpoint.EUCentral1;
                case "EUWest1": return Amazon.RegionEndpoint.EUWest1;
                default: return Amazon.RegionEndpoint.USEast1;
            }
        }

        public bool UploadFileToPath(string FilePath, string novoNome = "")
        {
            string Retorno = "";
            try
            {
                //define o ContentType dp arquivo
                string ContentType = "";

                //abre a conecao com o aws s3 atraves da credencial e region
                String AccessKeyID = this.AccessKeyIDS3;
                String SecretAccessKey = this.SecretAccessKeyS3;
                AWSCredentials credentials = new BasicAWSCredentials(AccessKeyID, SecretAccessKey);
                var client = new AmazonS3Client(credentials, GetRegion(this.RegionS3));

                //informa os dados do arquivo
                PutObjectRequest putRequest = new PutObjectRequest
                {
                    BucketName = this.BucketS3,//nome do bucket
                    Key = novoNome != "" ? novoNome : Path.GetFileName(FilePath), //pega o nome setado se não o nome original do arquivo
                    FilePath = FilePath, // o arquivo
                    ContentType = ContentType // tipo de arquivo
                };

                //realiza o upload do arquivo
                PutObjectResponse response = client.PutObject(putRequest);

                return true;
            }
            catch (AmazonS3Exception e)
            {
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool UploadFile(IFormFile file, string novoNome, string bucketName = "")
        {
            try
            {
                //define o ContentType dp arquivo
                string ContentType = file.ContentType;

                //abre a conecao com o aws s3 atraves da credencial e region
                String AccessKeyID = this.AccessKeyIDS3;
                String SecretAccessKey = this.SecretAccessKeyS3;
                AWSCredentials credentials = new BasicAWSCredentials(AccessKeyID, SecretAccessKey);
                AmazonS3Client client = new AmazonS3Client(credentials, GetRegion(this.RegionS3));

                //informa os dados do arquivo
                PutObjectRequest putRequest = new PutObjectRequest
                {
                    BucketName = this.BucketS3,//nome do bucket
                    Key = novoNome != "" ? novoNome : file.FileName, //nome do arquivo
                    InputStream = file.OpenReadStream(), // o arquivo
                    ContentType = ContentType // tipo de arquivo
                };


                //realiza o upload do arquivo
                PutObjectResponse response = client.PutObject(putRequest);

                return true;
            }
            catch (AmazonS3Exception)
            {
                return false;
            }
            catch (Exception)
            {
                return false;
            }

        }
        public bool UploadFileStream(Stream file, string novoNome)
        {
            try
            {
                //define o ContentType dp arquivo
                string ContentType = MimeMapping.GetMimeMapping(novoNome);

                //abre a conecao com o aws s3 atraves da credencial e region
                String AccessKeyID = this.AccessKeyIDS3;
                String SecretAccessKey = this.SecretAccessKeyS3;
                AWSCredentials credentials = new BasicAWSCredentials(AccessKeyID, SecretAccessKey);
                var client = new AmazonS3Client(credentials, GetRegion(this.RegionS3));

                //informa os dados do arquivo
                PutObjectRequest putRequest = new PutObjectRequest
                {
                    BucketName = this.BucketS3,//nome do bucket
                    Key = novoNome, //nome do arquivo
                    InputStream = file, // o arquivo
                    ContentType = ContentType // tipo de arquivo
                };

                //realiza o upload do arquivo
                PutObjectResponse response = client.PutObject(putRequest);

                return true;
            }
            catch (AmazonS3Exception)
            {
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public byte[] DownloadFile(string NomeArquivo)
        {
            byte[] bytes = default(byte[]);

            try
            {
                //abre a conecao com o aws s3 atraves da credencial e region
                String AccessKeyID = this.AccessKeyIDS3;
                String SecretAccessKey = this.SecretAccessKeyS3;
                AWSCredentials credentials = new BasicAWSCredentials(AccessKeyID, SecretAccessKey);
                var client = new AmazonS3Client(credentials, GetRegion(this.RegionS3));

                //monta o obj para ser realizado o request
                GetObjectRequest putRequest = new GetObjectRequest
                {
                    BucketName = this.BucketS3,
                    Key = NomeArquivo
                };

                //envia o requeste e obtem o arquivo
                using (GetObjectResponse response = client.GetObject(putRequest))
                {
                    //converte o GetObjectResponse em Stream
                    using (Stream responseStream = response.ResponseStream)
                    {
                        //converte o Stream em byte[]
                        bytes = ConverteStreamToByteArray(responseStream);
                    }
                }

                return bytes;
            }
            catch (AmazonS3Exception)
            {
                return bytes;
            }
            catch (Exception)
            {
                return bytes;
            }
        }

        public string GerarUrlPorTempo(string NomeArquivo)
        {
            string urlString = "";
            try
            {
                //abre a conecao com o aws s3 atraves da credencial e region
                String AccessKeyID = this.AccessKeyIDS3;
                String SecretAccessKey = this.SecretAccessKeyS3;
                AWSCredentials credentials = new BasicAWSCredentials(AccessKeyID, SecretAccessKey);
                var client = new AmazonS3Client(credentials, GetRegion(this.RegionS3));

                GetPreSignedUrlRequest putRequest = new GetPreSignedUrlRequest
                {
                    BucketName = this.BucketS3,
                    Key = NomeArquivo,
                    Expires = DateTime.Now.AddDays(1)
                };

                //envia o requeste e obtem o arquivo
                urlString = client.GetPreSignedURL(putRequest);


            }
            catch (AmazonS3Exception)
            {
                urlString = "";
            }
            catch (Exception)
            {
                urlString = "";
            }
            return urlString;
        }

        public bool DeleteFile(string NomeArquivo)
        {
            try
            {
                //abre a conecao com o aws s3 atraves da credencial e region
                String AccessKeyID = this.AccessKeyIDS3;
                String SecretAccessKey = this.SecretAccessKeyS3;
                AWSCredentials credentials = new BasicAWSCredentials(AccessKeyID, SecretAccessKey);
                var client = new AmazonS3Client(credentials, GetRegion(this.RegionS3));

                //monta o obj para ser realizado o request
                DeleteObjectRequest deleteObjectRequest = new DeleteObjectRequest
                {
                    BucketName = this.BucketS3,
                    Key = NomeArquivo
                };

                //envia ao servido o request para ser deletado do servidor
                DeleteObjectResponse response = client.DeleteObject(deleteObjectRequest);

                return true;
            }
            catch (AmazonS3Exception)
            {
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
        //Convert Stream em byte[] 
        private static byte[] ConverteStreamToByteArray(Stream stream)
        {
            byte[] byteArray = new byte[16 * 1024];
            using (MemoryStream mStream = new MemoryStream())
            {
                int bit;
                while ((bit = stream.Read(byteArray, 0, byteArray.Length)) > 0)
                {
                    mStream.Write(byteArray, 0, bit);
                }
                return mStream.ToArray();
            }
        }
    }
}
