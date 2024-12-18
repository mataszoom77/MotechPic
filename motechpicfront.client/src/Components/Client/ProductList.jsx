import { useEffect, useState } from "react";
import api from "../../services/api";

const ProductList = () => {
    const [products, setProducts] = useState([]);

    useEffect(() => {
        api.getClientProducts().then((res) => setProducts(res.data));
    }, []);

    return (
        <div>
            <h2>Available Products</h2>
            <ul>
                {products.map((product) => (
                    <li key={product.id}>{product.name}</li>
                ))}
            </ul>
        </div>
    );
};

export default ProductList;
