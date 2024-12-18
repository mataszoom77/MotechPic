import { BrowserRouter as Router, Routes, Route } from "react-router-dom";
import Homepage from "./components/Homepage";
import ProductList from "./components/Client/ProductList";
import ProductManagement from "./components/Admin/ProductManagement";
import Login from "./components/Auth/Login";
import AdminPage from "./Components/Admin/AdminPage";

function App() {
    return (
        <Router>
            <Routes>
                <Route path="/" element={<Homepage />} />
                <Route path="/products" element={<ProductList />} />
                <Route path="/admin/products" element={<ProductManagement />} />
                <Route path="/login" element={<Login />} />
                <Route path="/admin" element={<AdminPage />} />
            </Routes>
        </Router>
    );
}

export default App;
