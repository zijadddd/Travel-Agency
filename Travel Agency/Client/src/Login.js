import './css/Login.css';
import axios from 'axios';
import jwt from 'jwt-decode';
import { Link } from 'react-router-dom';
import { useState, useContext } from 'react';
import { AuthContext } from './helpers/AuthContext';
import { useNavigate } from 'react-router-dom';

const Login = () => {
    const [usernameState, setUsernameState] = useState('');
    const [passwordState, setPasswordState] = useState('');
    const { setAuthState } = useContext(AuthContext);
    const navigate = useNavigate();

    const handleUsername = (event) => {
        setUsernameState(event.target.value);
    };

    const handlePassword = (event) => {
        setPasswordState(event.target.value);
    };

    const login = async (event) => {
        event.preventDefault();
        let data = {
            username: usernameState,
            password: passwordState,
        };
        axios
            .post('https://localhost:7023/api/Auth/login', data)
            .then((response) => {
                localStorage.setItem('JWToken', response.data);
                const token = jwt(localStorage.getItem('JWToken'));
                setAuthState({
                    username: token.username,
                    role: token.role,
                    isLoggedIn: true,
                });
                navigate('/home');
            })
            .catch((error) => alert(error));
    };

    return (
        <div className="mainDiv d-flex justify-content-center align-items-center flex-column">
            <h1 className="text-white m-5">
                <span className="text-danger">T</span>ravel agency
            </h1>
            <div className="mainDiv__child d-flex flex-column">
                <h2 className="text-white">Sign in</h2>
                <form onSubmit={login}>
                    <div className="mb-3">
                        <label for="username" className="form-label text-white">
                            Username
                        </label>
                        <input
                            type="text"
                            className="form-control"
                            id="username"
                            aria-describedby="usernameHelp"
                            onChange={handleUsername}
                            required
                        />
                        <div id="usernameHelp" className="form-text">
                            We'll never share your private data with anyone
                            else.
                        </div>
                    </div>
                    <div className="mb-3">
                        <label for="password" className="form-label text-white">
                            Password
                        </label>
                        <input
                            type="password"
                            className="form-control"
                            id="password"
                            onChange={handlePassword}
                            required
                        />
                    </div>
                    <button type="submit" className="btn btn-danger">
                        Sign in
                    </button>
                    <p className="text-white mt-3">
                        You don't have an account ?{' '}
                        <Link
                            className="text-danger"
                            aria-current="page"
                            to="/registration"
                        >
                            Sign up
                        </Link>
                    </p>
                </form>
            </div>
        </div>
    );
};

export default Login;
