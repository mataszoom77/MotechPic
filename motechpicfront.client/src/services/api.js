import axios from "axios";

const API_URL = "https://localhost:5001"; // Replace with your backend URL

const api = {
    // Auth
    login: (credentials) => axios.post(`${API_URL}/auth/login`, credentials),

    // Client APIs
    getClientProducts: () => axios.get(`${API_URL}/clients/products`),
    getSpareParts: (productId) =>
        axios.get(`${API_URL}/clients/products/${productId}/spare-parts`),

    addRequest: (request) =>
        axios.post(`${API_URL}/clients/spare-part-requests`, request),

    // Admin APIs
    getAdminProducts: () => axios.get(`${API_URL}/admin/products`),
    addProduct: (product) => axios.post(`${API_URL}/admin/products`, product),
    updateProduct: (id, product) =>
        axios.put(`${API_URL}/admin/products/${id}`, product),
    deleteProduct: (id) => axios.delete(`${API_URL}/admin/products/${id}`),

    manageSpareParts: (productId, sparePart) =>
        axios.post(`${API_URL}/admin/products/${productId}/spare-parts`, sparePart),
};

export default api;
