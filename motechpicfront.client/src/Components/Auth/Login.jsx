import { useState } from "react";
import { useNavigate } from "react-router-dom";
import "./Login.css";
import logo from "../../assets/logo.svg";

const Login = () => {
    const [username, setUsername] = useState("");
    const [password, setPassword] = useState("");

    const navigate = useNavigate();

    const handleLogin = async () => {
        try {
            const response = await fetch("https://localhost:7171/auth/login", {
                method: "POST",
                headers: { "Content-Type": "application/json" },
                body: JSON.stringify({ username, password }),
            });

            if (!response.ok) {
                alert("Invalid username or password.");
                return;
            }

            const data = await response.json();
            localStorage.setItem("token", data.token);
            alert("Login successful!");
            navigate("/admin"); // Redirect to the admin page
        } catch (error) {
            console.error("Error during login:", error);
        }
    };

    return (
        <body>
            {/* Header */}
            <header className="homepage-header">
                <nav>
                    <a>Login</a>
                    <a href="/">Home</a>
                    <img src={logo} alt="MotechPic Logo" className="logo" />
                </nav>
            </header>

            {/* Main Content */}
            <main className="login-main">
                <h2>Admin Login</h2>
                <div className="login-form">
                    <input
                        type="text"
                        placeholder="Username"
                        value={username}
                        onChange={(e) => setUsername(e.target.value)}
                    />
                    <input
                        type="password"
                        placeholder="Password"
                        value={password}
                        onChange={(e) => setPassword(e.target.value)}
                    />
                    <button onClick={handleLogin}>Login</button>
                </div>
            </main>

            {/* Footer */}
            <footer className="homepage-footer">
                <div className="footer-content">
                    <p>Made by Matas Juskys IFF-0/5</p>
                </div>
            </footer>
        </body>
    );
};

export default Login;
