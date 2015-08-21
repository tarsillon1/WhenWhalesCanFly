using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using EasyJSON;

public class EasyJSONExample : MonoBehaviour {

	IEnumerator Start () {

        // Let's construct our entity
        Box box = new Box();
        box.dimension = new Vector3(2f, 1.5f, 3f);

        Product product1 = new Product();
        product1.name = "Cheese";
        product1.description = "Cheese made by a firefighter from Boston, Texas.";
        product1.price = 9.99f;
        box.products.Add(product1);

        Product product2 = new Product();
        product2.name = "Ham";
        product2.description = "Ham from Tokyo, Argentina.";
        product2.price = 69.69f;
        box.products.Add(product2);

        Product product3 = new Product();
        product3.name = "Bread";
        product3.description = "Bread gently cooked by your mother.";
        product3.price = 13.31f;
        box.products.Add(product3);

        // Serialize the entity into a JSON string
        string output = Serializer.Serialize<Box>(box);
        Debug.Log("Compressed Json:\n" + output);

        string prettyOutput = Serializer.Serialize<Box>(box, true);
        Debug.Log("Pretty Json:\n" + prettyOutput);

        // Now we deserialize the JSON string to construct the entity
        Box deserializedBox = Serializer.Deserialize<Box>(output);
        // or Box deserializedBox = output.Deserialize<Box>();

        Debug.Log(string.Format("Box with {0} product(s) and dimension {1}.", deserializedBox.quantity, deserializedBox.dimension));

        // We can also deserialize a JSON string directly from a WWW object
        WWW www = new WWW("http://www.takohi.com/data/unity/assets/easyjson/box.json");
        yield return www;
        Box wwwBox = www.Deserialize<Box>();

        Debug.Log(string.Format("Box with {0} product(s) and dimension {1}.", wwwBox.quantity, wwwBox.dimension));
	}

    public class Product {
        public string name;
        public string description;
        public float price;
    }

    public class Box {
        public Vector3 dimension;
        public List<Product> products = new List<Product>();
        public int quantity {
            get {
                return products.Count;
            }
        }
    }
}
