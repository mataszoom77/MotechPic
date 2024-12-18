import { useEffect, useState } from "react";
import { Link } from "react-router-dom";
import "./Homepage.css";
import logo from "../assets/logo.svg"; // Import the SVG logo


const Homepage = () => {
    const [products, setProducts] = useState([]);

    // Fetch products from the backend
    useEffect(() => {
        const fetchProducts = async () => {
            try {
                const response = await fetch("https://localhost:7171/clients/products");
                const data = await response.json();
                setProducts(data);
            } catch (error) {
                console.error("Error fetching products:", error);
            }
        };

        fetchProducts();
    }, []);

    return (
        <body>
            {/* Header Section */}
            <header className="homepage-header">
                <nav>
                    <Link to="/login">Log In</Link>
                    <Link to="/clients/products">Products</Link>
                    <Link to="/about">About Me</Link>
                    <img src={logo} alt="MotechPic Logo" className="logo" />
                </nav>
            </header>

            {/* Main Content */}
            <main className="homepage-main">
                <h2>Available Products</h2>
                <div className="product-list">
                    {products.length > 0 ? (
                        products.map((product) => (
                            <div key={product.id} className="product-card">
                                <h3>{product.name}</h3>
                                <p>{product.description}</p>
                                <span>Price: ${product.price}</span>
                            </div>
                        ))
                    ) : (
                        <p className="no-products">No products available.</p>
                    )}
                </div>
            </main>

            <footer className="homepage-footer">
                <div className="footer-content">
                    <p>Made by Matas Juskys IFF-0/5</p>
                </div>
            </footer>
        </body>
    );
};

export default Homepage;
