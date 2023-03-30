import './css/App.css';
import { AuthContext } from './helpers/AuthContext';
import Login from './Login';
import { BrowserRouter as Router, Route, Routes } from 'react-router-dom';
import { useEffect, useState } from 'react';
import axios from 'axios';

function App() {
    const [authState, setAuthState] = useState({
        username: '',
        role: '',
        isLoggedIn: false,
    });
    return (
        <AuthContext.Provider value={{ authState, setAuthState }}>
            <div className="root">
                <Router>
                    <Routes>
                        <Route path="/" element={<Login />} />
                    </Routes>
                </Router>
            </div>
        </AuthContext.Provider>
    );
}

export default App;
