import React from 'react';

const Input = ({ onChange, onButtonClick }) => {
    const handleKeyPress = (event) => {
        if (event.key === 'Enter') {
            onButtonClick();
        }
    };

    return (
        <div className="input-wrapper">
            <img className="search-btn" src="/icons/search.svg" />
            <input
                onChange={onChange}
                onKeyPress={handleKeyPress}
                className="input"
                type="text"
                placeholder="E.g. Pikachu"
            />
            <button onClick={onButtonClick} className="btn">GO</button>
        </div>
    );
};

export default Input;
