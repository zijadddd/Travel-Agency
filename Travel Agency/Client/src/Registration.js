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
        const regex = /^[A-Z][a-z0-9_-]{3,19}$/;
        const value = event.target.value;
        const isFirstNameValid = regex.test(value);
        setFirstNameState({ value, error: !isFirstNameValid });
        if (showFirstNameErrorMessage && isFirstNameValid)
            setShowFirstNameErrorMessage(false);
    };

    const handleLastName = (event) => {
        const regex = /^[A-Z][a-z0-9_-]{3,19}$/;
        const value = event.target.value;
        const isLastNameValid = regex.test(value);
        setLastNameState({ value, error: !isLastNameValid });
        if (showLastNameErrorMessage && isLastNameValid)
            setShowLastNameErrorMessage(false);
    };

    const handleEmail = (event) => {
        const regex = /^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/;
        const value = event.target.value;
        const isEmailValid = regex.test(value);
        setEmailState({ value, error: !isEmailValid });
        if (showEmailErrorMessage && isEmailValid)
            setShowEmailErrorMessage(false);
    };

    const handlePassword = (event) => {
        const value = event.target.value;
        const isPasswordValid = value.length >= 8 ? true : false;
        setPasswordState({ value, error: !isPasswordValid });
        if (showPasswordErrorMessage && isPasswordValid)
            setShowPasswordErrorMessage(false);
    };

    const handleCity = (event) => {
        const regex = /^[A-Z]\s*[a-zA-Z]{1}[0-9a-zA-Z][0-9a-zA-Z '-.=#/]*$/;
        const value = event.target.value;
        const isCityValid = regex.test(value);
        setCityState({ value, error: !isCityValid });
        if (showCityErrorMessage && isCityValid) setShowCityErrorMessage(false);
    };

    const handleAddress = (event) => {
        const regex = /^[A-Z]\s*[a-zA-Z]{1}[0-9a-zA-Z][0-9a-zA-Z '-.=#/]*$/;
        const value = event.target.value;
        const isAddressValid = regex.test(value);
        setAddressState({ value, error: !isAddressValid });
        if (showAddressErrorMessage && isAddressValid)
            setShowAddressErrorMessage(false);
    };

    const handlePhoneNumber = (event) => {
        const regex = /^\d{10}$/;
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
                <h2 className="text-white">Sign in</h2>
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
                                Your password need to be at least{' '}
                                <span className="text-danger">
                                    8 characters
                                </span>{' '}
                                long.
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
                                <span className="text-danger">valid</span>{' '}
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
                                number. Example: 0603456981
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
