import React from 'react';
import Input from "./Input";

const Finder = ({...props}) => {
    return (
        <div className="finder">
            <div className="finder-wrapper">
                <h1 className="h1">Who are you looking&nbsp;for?</h1>
                <img className="pokeball" alt="" src="/icons/Pokeball.svg"/>
            </div>
            <div className="finder-input">
                <Input {...props} />
            </div>
        </div>
    );
};

export default Finder;