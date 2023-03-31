import './css/Registration.css';
import axios from 'axios';
import { Link } from 'react-router-dom';
import { useState } from 'react';
import { useNavigate } from 'react-router-dom';
import { useForm } from 'react-hook-form';

const Registration = () => {
    const [firstNameState, setFirstNameState] = useState('');
    const [lastNameState, setLastNameState] = useState('');
    const [emailState, setEmailState] = useState('');
    const [passwordState, setPasswordState] = useState('');
    const [addressState, setAddressState] = useState('');
    const [cityState, setCityState] = useState('');
    const [phoneNumberState, setPhoneNumberState] = useState('');
    const [roleState, setRoleState] = useState('');
    const [handlingOkayState, setHandlingOkayState] = useState('');
    const { register, handleSubmit } = useForm();

    const navigate = useNavigate();

    const handleFirstName = (firstName) => {
        const regex = /^[A-Z][a-z0-9_-]{3,19}$/;
        if (!regex.test(firstName)) {
            alert('Please enter valid first name. Example: John not john');
            document.getElementById('firstNameInput').focus();
            setHandlingOkayState(false);
        }
        setFirstNameState(firstName);
    };

    const handleLastName = (lastName) => {
        const regex = /^[A-Z][a-z0-9_-]{3,19}$/;
        if (!regex.test(lastName)) {
            alert('Please enter valid last name. Example: Smith not smith');
            document.getElementById('lastNameInput').focus();
            setHandlingOkayState(false);
        }
        setLastNameState(lastName);
    };

    const handleEmail = (email) => {
        const regex = /^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/;
        if (!regex.test(email)) {
            alert('Please enter valid email. Example: johnsmith@gmail.com');
            document.getElementById('emailInput').focus();
            setHandlingOkayState(false);
        }
        setEmailState(email);
    };

    const handlePassword = (password) => {
        if (password.length < 8) {
            alert('Password need to be at least 8 characters long.');
            document.getElementById('passwordInput').focus();
            setHandlingOkayState(false);
        }
        setPasswordState(password);
    };

    const handleAddress = (address) => {
        var regex = /^[A-Z]\s*[a-zA-Z]{1}[0-9a-zA-Z][0-9a-zA-Z '-.=#/]*$/;
        if (!regex.test(address)) {
            alert('Please enter valid address. Example: Address bb.');
            document.getElementById('cityInput').focus();
            setHandlingOkayState(false);
        }
        setAddressState(address);
    };

    const handleCity = (city) => {
        var regex = /^[A-Z]\s*[a-zA-Z]{1}[0-9a-zA-Z][0-9a-zA-Z '-.=#/]*$/;
        if (!regex.test(city)) {
            alert('Please enter valid city name. Example: New York.');
            document.getElementById('cityInput').focus();
            setHandlingOkayState(false);
        }
        setCityState(city);
    };

    const handlePhoneNumber = (phoneNumber) => {
        var regex = /^\d{10}$/;
        if (!regex.test(phoneNumber)) {
            alert('Please enter valid phone number. Example: 9867345673');
            document.getElementById('phoneNumberInput').focus();
            setHandlingOkayState(false);
        }
        setPhoneNumberState(phoneNumber);
    };

    const handleRole = () => {
        setRoleState('User');
    };

    const registration = async (event) => {
        setHandlingOkayState(true);
        handleFirstName(event.firstName);
        handleLastName(event.lastName);
        handleEmail(event.email);
        handlePassword(event.password);
        handleCity(event.city);
        handleAddress(event.address);
        handlePhoneNumber(event.phoneNumber);
        handleRole();
        if (handlingOkayState) {
            let data = {
                firstName: firstNameState,
                lastName: lastNameState,
                email: emailState,
                password: passwordState,
                address: addressState,
                city: cityState,
                phoneNumber: phoneNumberState,
                role: roleState,
            };
            axios
                .post('https://localhost:7023/api/Auth/registration', data)
                .then((response) => {
                    if (!response.ok) throw response;
                    navigate('/home');
                })
                .catch((error) => alert(error));
        }
    };

    return (
        <div className="mainDiv d-flex justify-content-center align-items-center flex-column">
            <h1 className="text-white m-2">
                <span className="text-danger">T</span>ravel agency
            </h1>
            <div className="mainDiv__child d-flex flex-column m-3">
                <h2 className="text-white">Sign in</h2>
                <form onSubmit={handleSubmit(registration)}>
                    <div className="mb-3">
                        <label
                            for="firstNameInput"
                            className="form-label text-white"
                        >
                            First name
                        </label>
                        <input
                            type="text"
                            className="form-control"
                            id="firstNameInput"
                            {...register('firstName')}
                            required
                        />
                    </div>
                    <div className="mb-3">
                        <label
                            for="lastNameInput"
                            className="form-label text-white"
                        >
                            Last name
                        </label>
                        <input
                            type="text"
                            className="form-control"
                            id="lastNameInput"
                            {...register('lastName')}
                            required
                        />
                    </div>
                    <div className="mb-3">
                        <label
                            for="emailInput"
                            className="form-label text-white"
                        >
                            Email
                        </label>
                        <input
                            type="text"
                            className="form-control"
                            id="emailInput"
                            {...register('email')}
                            required
                        />
                    </div>
                    <div className="mb-3">
                        <label
                            for="passwordInput"
                            className="form-label text-white"
                        >
                            Password
                        </label>
                        <input
                            type="password"
                            className="form-control"
                            id="passwordInput"
                            {...register('password')}
                            required
                        />
                    </div>
                    <div className="mb-3">
                        <label
                            for="cityInput"
                            className="form-label text-white"
                        >
                            City
                        </label>
                        <input
                            type="text"
                            className="form-control"
                            id="cityInput"
                            {...register('city')}
                            required
                        />
                    </div>
                    <div className="mb-3">
                        <label
                            for="addressInput"
                            className="form-label text-white"
                        >
                            Address
                        </label>
                        <input
                            type="text"
                            className="form-control"
                            id="addressInput"
                            {...register('address')}
                            required
                        />
                    </div>
                    <div className="mb-3">
                        <label
                            for="phoneNumberInput"
                            className="form-label text-white"
                        >
                            Phone number
                        </label>
                        <input
                            type="text"
                            className="form-control"
                            id="phoneNumberInput"
                            {...register('phoneNumber')}
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

export default Registration;
