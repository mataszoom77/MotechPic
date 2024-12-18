import { useEffect, useState } from "react";
import { Link } from "react-router-dom";
import "../Homepage.css";
import logo from "../../assets/logo.svg";
import PropTypes from "prop-types";

// Edit Product Modal
const EditProductModal = ({ product, onClose, onSave }) => {
    const [name, setName] = useState(product.name);
    const [description, setDescription] = useState(product.description);
    const [price, setPrice] = useState(product.price);

    const handleSave = () => {
        onSave({ ...product, name, description, price });
    };

    return (
        <div className="modal-overlay">
            <div className="modal-content">
                <h3>Edit Product</h3>
                <label>Name:</label>
                <input
                    type="text"
                    value={name}
                    onChange={(e) => setName(e.target.value)}
                />

                <label>Description:</label>
                <textarea
                    value={description}
                    onChange={(e) => setDescription(e.target.value)}
                />

                <label>Price:</label>
                <input
                    type="number"
                    value={price}
                    onChange={(e) => setPrice(e.target.value)}
                />

                <div className="modal-buttons">
                    <button onClick={handleSave} className="save-btn">Save</button>
                    <button onClick={onClose} className="cancel-btn">Cancel</button>
                </div>
            </div>
        </div>
    );
};

EditProductModal.propTypes = {
    product: PropTypes.shape({
        id: PropTypes.number.isRequired,
        name: PropTypes.string.isRequired,
        description: PropTypes.string.isRequired,
        price: PropTypes.oneOfType([PropTypes.number, PropTypes.string]).isRequired,
    }).isRequired,
    onClose: PropTypes.func.isRequired,
    onSave: PropTypes.func.isRequired,
};

// Create Product Modal
const CreateProductModal = ({ onClose, onSave }) => {
    const [name, setName] = useState("");
    const [description, setDescription] = useState("");
    const [price, setPrice] = useState("");

    const handleSave = () => {
        if (name && description && price) {
            onSave({ name, description, price: parseFloat(price) });
        } else {
            alert("Please fill in all fields.");
        }
    };

    return (
        <div className="modal-overlay">
            <div className="modal-content">
                <h3>Create New Product</h3>
                <label>Name:</label>
                <input
                    type="text"
                    placeholder="Enter product name"
                    value={name}
                    onChange={(e) => setName(e.target.value)}
                />

                <label>Description:</label>
                <textarea
                    placeholder="Enter product description"
                    value={description}
                    onChange={(e) => setDescription(e.target.value)}
                />

                <label>Price:</label>
                <input
                    type="number"
                    placeholder="Enter product price"
                    value={price}
                    onChange={(e) => setPrice(e.target.value)}
                />

                <div className="modal-buttons">
                    <button onClick={handleSave} className="save-btn">Save</button>
                    <button onClick={onClose} className="cancel-btn">Cancel</button>
                </div>
            </div>
        </div>
    );
};

CreateProductModal.propTypes = {
    onClose: PropTypes.func.isRequired,
    onSave: PropTypes.func.isRequired,
};

// Admin Page Component
const AdminPage = () => {
    const [products, setProducts] = useState([]);
    const [selectedProduct, setSelectedProduct] = useState(null);
    const [showCreateModal, setShowCreateModal] = useState(false);

    // Fetch products
    useEffect(() => {
        const fetchProducts = async () => {
            try {
                const response = await fetch("https://localhost:7171/admin/products", {
                    headers: { Authorization: `Bearer ${localStorage.getItem("token")}` }
                });
                const data = await response.json();
                setProducts(data);
            } catch (error) {
                console.error("Error fetching products:", error);
            }
        };

        fetchProducts();
    }, []);

    // Handle Create Product
    const handleCreateProduct = async (newProduct) => {
        try {
            const response = await fetch("https://localhost:7171/admin/products", {
                method: "POST",
                headers: {
                    "Content-Type": "application/json",
                    Authorization: `Bearer ${localStorage.getItem("token")}`,
                },
                body: JSON.stringify(newProduct),
            });

            if (response.ok) {
                const createdProduct = await response.json();
                setProducts([...products, createdProduct]);
                setShowCreateModal(false);
                alert("Product created successfully!");
            } else {
                alert("Failed to create product.");
            }
        } catch (error) {
            console.error("Error creating product:", error);
        }
    };

    // Handle Update Product
    const handleSaveProduct = async (updatedProduct) => {
        try {
            const response = await fetch(
                `https://localhost:7171/admin/products/${updatedProduct.id}`,
                {
                    method: "PUT",
                    headers: {
                        "Content-Type": "application/json",
                        Authorization: `Bearer ${localStorage.getItem("token")}`
                    },
                    body: JSON.stringify(updatedProduct)
                }
            );

            if (response.ok) {
                setProducts(products.map((product) =>
                    product.id === updatedProduct.id ? updatedProduct : product
                ));
                setSelectedProduct(null);
                alert("Product updated successfully!");
            } else {
                alert("Failed to update product.");
            }
        } catch (error) {
            console.error("Error updating product:", error);
        }
    };

    // Handle Delete Product
    const handleDelete = async (productId) => {
        try {
            const response = await fetch(`https://localhost:7171/admin/products/${productId}`, {
                method: "DELETE",
                headers: { Authorization: `Bearer ${localStorage.getItem("token")}` }
            });

            if (response.ok) {
                setProducts(products.filter((product) => product.id !== productId));
                alert("Product deleted successfully.");
            } else {
                alert("Failed to delete the product.");
            }
        } catch (error) {
            console.error("Error deleting product:", error);
        }
    };

    return (
        <div>
            {/* Header */}
            <header className="homepage-header">
                <nav>
                    <a><Link to="/logout">Log Out</Link></a>
                    <a><Link to="/clients/products">Products</Link></a>
                    <img src={logo} alt="MotechPic Logo" className="logo" />
                    <button
                        className="add-product-btn"
                        onClick={() => setShowCreateModal(true)}
                    >
                        + Add Product
                    </button>
                </nav>
            </header>

            {/* Main Content */}
            <main className="homepage-main">
                <h2>Admin: Product Management</h2>
                <div className="product-list">
                    {products.length > 0 ? (
                        products.map((product) => (
                            <div key={product.id} className="product-card">
                                <h3>{product.name}</h3>
                                <p>{product.description}</p>
                                <span>Price: ${product.price}</span>
                                <div className="admin-actions">
                                    <button
                                        className="edit-btn"
                                        onClick={() => setSelectedProduct(product)}
                                    >
                                        Edit
                                    </button>
                                    <button
                                        className="delete-btn"
                                        onClick={() => handleDelete(product.id)}
                                    >
                                        Delete
                                    </button>
                                </div>
                            </div>
                        ))
                    ) : (
                        <p>No products available.</p>
                    )}
                </div>
            </main>

            {/* Modals */}
            {showCreateModal && (
                <CreateProductModal
                    onClose={() => setShowCreateModal(false)}
                    onSave={handleCreateProduct}
                />
            )}
            {selectedProduct && (
                <EditProductModal
                    product={selectedProduct}
                    onClose={() => setSelectedProduct(null)}
                    onSave={handleSaveProduct}
                />
            )}
        </div>
    );
};

export default AdminPage;
