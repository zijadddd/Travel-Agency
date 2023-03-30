import { useContext, useEffect } from 'react';
import { AuthContext } from './helpers/AuthContext';
import { useNavigate } from 'react-router-dom';

const Home = () => {
    const { authState, setAuthState } = useContext(AuthContext);
    const navigate = useNavigate();

    useEffect(() => {}, [authState]);
};

export default Home;
