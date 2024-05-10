import React from 'react';

const Input = ({...props}) => {
    return (
        <div className="input-wrapper">
            <img className="search-btn" src="https://raw.githubusercontent.com/s1ches/ORIS2/4864b60dad4cadeb97287dae7e0039d456ffbdfc/pokemon/public/icons/search.svg"/>
            <input {...props} className="input" type="text" placeholder="E.g. Pikachu"/>
            <button className="btn">GO</button>
        </div>
    );
};

export default Input;