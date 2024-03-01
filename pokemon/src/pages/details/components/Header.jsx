import React from 'react';
import {Link} from "react-router-dom";

const Header = () => {
    return (
        <div className="finder" style={{paddingBottom: "20px"}}>
            <div className="finder-wrapper">
                <Link className="back-link" to={"/"}><img alt="" className="back" src="/icons/arrow.svg"/></Link>
                <img className="pokeball" alt="" src="/icons/Pokeball.svg"/>
            </div>
        </div>
    );
};

export default Header;