using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Data;
using System.Web.UI.WebControls;

namespace WcfService
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IService1" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IService1
    {
        /*
        [OperationContract]
        string GetData(int value);

        [OperationContract]
        CompositeType GetDataUsingDataContract(CompositeType composite);
        */

        // TODO: agregue aquí sus operaciones de servicio

        [OperationContract]
        string ValidateUser(User user1);

        [OperationContract]
        string ListBooks();

        [OperationContract]
        string SearchBook(string letter);

    }

    /*
    // Utilice un contrato de datos, como se ilustra en el ejemplo siguiente, para agregar tipos compuestos a las operaciones de servicio.
    [DataContract]
    public class CompositeType
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }
    */

    [DataContract]
    public class User
    {
        [DataMember]
        public int idUser { get; set; }
        [DataMember]
        public string email { get; set; }
        [DataMember]
        public string password { get; set; }
        [DataMember]
        public bool status { get; set; }

    }

    [DataContract]
    public class Books
    {
        [DataMember]
        public int idBook { get; set; }
        [DataMember]
        public string varTitle { get; set; }
        [DataMember]
        public string varCode { get; set; }
        [DataMember]
        public bool bitStatus { get; set; }
        [DataMember]
        public string dmeDateCreate { get; set; }
        [DataMember]
        public string dmeDateUpdate { get; set; }
        [DataMember]
        public string isActive { get; set; }
    }

}
