import { useEffect, useState } from "react";
import api from "../../services/api";

const ProductManagement = () => {
    const [products, setProducts] = useState([]);
    const [newProduct, setNewProduct] = useState({ name: "", description: "" });

    useEffect(() => {
        loadProducts();
    }, []);

    const loadProducts = () => {
        api.getAdminProducts().then((res) => setProducts(res.data));
    };

    const addProduct = () => {
        api.addProduct(newProduct).then(() => {
            loadProducts();
            setNewProduct({ name: "", description: "" });
        });
    };

    return (
        <div>
            <h2>Product Management</h2>
            <input
                placeholder="Name"
                onChange={(e) => setNewProduct({ ...newProduct, name: e.target.value })}
            />
            <input
                placeholder="Description"
                onChange={(e) =>
                    setNewProduct({ ...newProduct, description: e.target.value })
                }
            />
            <button onClick={addProduct}>Add Product</button>
            <ul>
                {products.map((product) => (
                    <li key={product.id}>{product.name}</li>
                ))}
            </ul>
        </div>
    );
};

export default ProductManagement;
