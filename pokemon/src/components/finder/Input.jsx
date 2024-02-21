import React from 'react';

const Input = () => {
    return (
        <div className="input-wrapper">
            <img className="search-btn" src="/icons/search.svg"/>
            <input className="input" type="text" placeholder="E.g. Pikachu"/>
            <button className="btn">GO</button>
        </div>
    );
};

export default Input;