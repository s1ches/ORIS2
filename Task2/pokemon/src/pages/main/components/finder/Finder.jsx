import React from 'react';
import Input from "./Input";

const Finder = ({...props}) => {
    return (
        <div className="finder">
            <div className="finder-wrapper">
                <h1 className="h1">Who are you looking&nbsp;for?</h1>
                <img className="pokeball" alt="" src="https://raw.githubusercontent.com/s1ches/ORIS2/4864b60dad4cadeb97287dae7e0039d456ffbdfc/pokemon/public/icons/Pokeball.svg"/>
            </div>
            <div className="finder-input">
                <Input {...props} />
            </div>
        </div>
    );
};

export default Finder;