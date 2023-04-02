import './css/Registration.css';
import axios from 'axios';
import { Link } from 'react-router-dom';
import { useState } from 'react';
import { useNavigate } from 'react-router-dom';

const Registration = () => {
    const [firstNameState, setFirstNameState] = useState({
        error: false,
        value: '',
    });
    const [lastNameState, setLastNameState] = useState({
        error: false,
        value: '',
    });
    const [emailState, setEmailState] = useState({
        error: false,
        value: '',
    });
    const [passwordState, setPasswordState] = useState({
        error: false,
        value: '',
    });
    const [addressState, setAddressState] = useState({
        error: false,
        value: '',
    });
    const [cityState, setCityState] = useState({
        error: false,
        value: '',
    });
    const [phoneNumberState, setPhoneNumberState] = useState({
        error: false,
        value: '',
    });
    const [showFirstNameErrorMessage, setShowFirstNameErrorMessage] =
        useState(false);
    const [showLastNameErrorMessage, setShowLastNameErrorMessage] =
        useState(false);
    const [showEmailErrorMessage, setShowEmailErrorMessage] = useState(false);
    const [showPasswordErrorMessage, setShowPasswordErrorMessage] =
        useState(false);
    const [showCityErrorMessage, setShowCityErrorMessage] = useState(false);
    const [showAddressErrorMessage, setShowAddressErrorMessage] =
        useState(false);
    const [showPhoneNumberErrorMessage, setShowPhoneNumberErrorMessage] =
        useState(false);
    const [alertMessageState, setAlertMessageState] = useState({
        message: '',
        visible: false,
    });

    const navigate = useNavigate();

    const handleFirstName = (event) => {
        const regex = /^[A-Z][a-z]+$/;
        const value = event.target.value;
        const isFirstNameValid = regex.test(value);
        setFirstNameState({ value, error: !isFirstNameValid });
        if (showFirstNameErrorMessage && isFirstNameValid)
            setShowFirstNameErrorMessage(false);
    };

    const handleLastName = (event) => {
        const regex = /^[A-Z][a-z]+(-[A-Z][a-z]+)*$/;
        const value = event.target.value;
        const isLastNameValid = regex.test(value);
        setLastNameState({ value, error: !isLastNameValid });
        if (showLastNameErrorMessage && isLastNameValid)
            setShowLastNameErrorMessage(false);
    };

    const handleEmail = (event) => {
        const regex = /^[\w.%+-]+@[a-z0-9.-]+\.[a-z]{2,}$/i;
        const value = event.target.value;
        const isEmailValid = regex.test(value);
        setEmailState({ value, error: !isEmailValid });
        if (showEmailErrorMessage && isEmailValid)
            setShowEmailErrorMessage(false);
    };

    const handlePassword = (event) => {
        const regex =
            /^(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*#?&])[A-Za-z\d@$!%*#?&]{8,}$/;
        const value = event.target.value;
        const isPasswordValid = regex.test(value);
        setPasswordState({ value, error: !isPasswordValid });
        if (showPasswordErrorMessage && isPasswordValid)
            setShowPasswordErrorMessage(false);
    };

    const handleCity = (event) => {
        const regex = /^[A-Z][a-z]+(?:[\s-][A-Z][a-z]+)*$/;
        const value = event.target.value;
        const isCityValid = regex.test(value);
        setCityState({ value, error: !isCityValid });
        if (showCityErrorMessage && isCityValid) setShowCityErrorMessage(false);
    };

    const handleAddress = (event) => {
        const regex = /^[A-Z][\p{L}\d\s.,-]*$/u;
        const value = event.target.value;
        const isAddressValid = regex.test(value);
        setAddressState({ value, error: !isAddressValid });
        if (showAddressErrorMessage && isAddressValid)
            setShowAddressErrorMessage(false);
    };

    const handlePhoneNumber = (event) => {
        const regex = /^(\+?\d{1,3}\s)?\(?\d{3}\)?[-.\s]?\d{3}[-.\s]?\d{3,4}$/;
        const value = event.target.value;
        const isPhoneNumberValid = regex.test(value);
        setPhoneNumberState({ value, error: !isPhoneNumberValid });
        if (showPhoneNumberErrorMessage && isPhoneNumberValid)
            setShowPhoneNumberErrorMessage(false);
    };

    const handleFirstNameBlur = () => {
        if (firstNameState.error) setShowFirstNameErrorMessage(true);
    };

    const handleLastNameBlur = () => {
        if (lastNameState.error) setShowLastNameErrorMessage(true);
    };

    const handleEmailBlur = () => {
        if (emailState.error) setShowEmailErrorMessage(true);
    };

    const handlePasswordBlur = () => {
        if (passwordState.error) setShowPasswordErrorMessage(true);
    };

    const handleCityBlur = () => {
        if (cityState.error) setShowCityErrorMessage(true);
    };

    const handleAddressBlur = () => {
        if (addressState.error) setShowAddressErrorMessage(true);
    };

    const handlePhoneNumberBlur = () => {
        if (phoneNumberState.error) setShowPhoneNumberErrorMessage(true);
    };

    const registration = async (event) => {
        event.preventDefault();
        if (firstNameState.error) {
            setAlertMessageState({
                message: 'You need to enter valid first name.',
                visible: true,
            });
            setTimeout(
                () => setAlertMessageState({ message: '', visible: false }),
                3000
            );
            return;
        }
        if (lastNameState.error) {
            setAlertMessageState({
                message: 'You need to enter valid last name.',
                visible: true,
            });
            setTimeout(
                () => setAlertMessageState({ message: '', visible: false }),
                3000
            );
            return;
        }
        if (emailState.error) {
            setAlertMessageState({
                message: 'You need to enter valid email.',
                visible: true,
            });
            setTimeout(
                () => setAlertMessageState({ message: '', visible: false }),
                3000
            );
            return;
        }
        if (passwordState.error) {
            setAlertMessageState({
                message: 'You need to enter valid password.',
                visible: true,
            });
            setTimeout(
                () => setAlertMessageState({ message: '', visible: false }),
                3000
            );
            return;
        }
        if (cityState.error) {
            setAlertMessageState({
                message: 'You need to enter valid city name.',
                visible: true,
            });
            setTimeout(
                () => setAlertMessageState({ message: '', visible: false }),
                3000
            );
            return;
        }
        if (addressState.error) {
            setAlertMessageState({
                message: 'You need to enter valid address.',
                visible: true,
            });
            setTimeout(
                () => setAlertMessageState({ message: '', visible: false }),
                3000
            );
            return;
        }
        if (phoneNumberState.error) {
            setAlertMessageState({
                message: 'You need to enter valid phone number.',
                visible: true,
            });
            setTimeout(
                () => setAlertMessageState({ message: '', visible: false }),
                3000
            );
            return;
        }
        let data = {
            firstName: firstNameState.value,
            lastName: lastNameState.value,
            email: emailState.value,
            password: passwordState.value,
            city: cityState.value,
            address: addressState.value,
            phoneNumber: phoneNumberState.value,
            role: 'User',
        };
        console.log(data);
        axios
            .post('https://localhost:7023/api/Auth/registration', data)
            .then((response) => {
                if (!response.ok) throw response;
                navigate('/home');
            })
            .catch((error) => alert(error));
    };

    return (
        <div className="mainDiv d-flex justify-content-center align-items-center flex-column">
            <h1 className="text-white m-2">
                <span className="text-danger">T</span>ravel agency
            </h1>
            <div className="mainDiv__child d-flex flex-column m-3">
                <h2 className="text-white">Sign up</h2>
                <form onSubmit={registration}>
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
                            onChange={handleFirstName}
                            onBlur={handleFirstNameBlur}
                            required
                        />
                        {showFirstNameErrorMessage && (
                            <p className="text-white errorMessage">
                                Please enter a{' '}
                                <span className="text-danger">valid</span> first
                                name. Example: John
                            </p>
                        )}
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
                            onChange={handleLastName}
                            onBlur={handleLastNameBlur}
                            required
                        />
                        {showLastNameErrorMessage && (
                            <p className="text-white errorMessage">
                                Please enter a{' '}
                                <span className="text-danger">valid</span> last
                                name. Example: Smith
                            </p>
                        )}
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
                            onChange={handleEmail}
                            onBlur={handleEmailBlur}
                            required
                        />
                        {showEmailErrorMessage && (
                            <p className="text-white errorMessage">
                                Please enter a{' '}
                                <span className="text-danger">valid</span> email
                                address. Example: johnsmith@gmail.com
                            </p>
                        )}
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
                            onChange={handlePassword}
                            onBlur={handlePasswordBlur}
                            required
                        />
                        {showPasswordErrorMessage && (
                            <p className="text-white errorMessage">
                                The password should consist of at least{' '}
                                <span className="text-danger">8 letters</span>,
                                al least{' '}
                                <span className="text-danger">one capital</span>{' '}
                                letter, <span className="text-danger">one</span>{' '}
                                number and{' '}
                                <span className="text-danger">one special</span>{' '}
                                character. Example: Abc123!@
                            </p>
                        )}
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
                            onChange={handleCity}
                            onBlur={handleCityBlur}
                            required
                        />
                        {showCityErrorMessage && (
                            <p className="text-white errorMessage">
                                Please enter a{' '}
                                <span className="text-danger">valid</span> city
                                name. Example: New York
                            </p>
                        )}
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
                            onChange={handleAddress}
                            onBlur={handleAddressBlur}
                            required
                        />
                        {showAddressErrorMessage && (
                            <p className="text-white errorMessage">
                                Please enter a{' '}
                                <span className="text-danger">valid</span> home
                                address. Example: Time Square bb
                            </p>
                        )}
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
                            onChange={handlePhoneNumber}
                            onBlur={handlePhoneNumberBlur}
                            required
                        />
                        {showPhoneNumberErrorMessage && (
                            <p className="text-white errorMessage">
                                Please enter a{' '}
                                <span className="text-danger">valid</span> phone
                                number. Examples: +1 (123) 456-7890,
                                555-555-1234, +44 1234567890, 123-456-789
                            </p>
                        )}
                    </div>
                    {alertMessageState.visible ? (
                        <p className="text-white errorMessage">
                            <span className="text-danger">WARNING: </span>{' '}
                            {alertMessageState.message}
                        </p>
                    ) : (
                        <></>
                    )}
                    <button type="submit" className="btn btn-danger">
                        Sign in
                    </button>
                    <p className="text-white mt-3">
                        Already have an account ?{' '}
                        <Link
                            className="text-danger"
                            aria-current="page"
                            to="/"
                        >
                            Sign in
                        </Link>
                    </p>
                </form>
            </div>
        </div>
    );
};

export default Registration;
