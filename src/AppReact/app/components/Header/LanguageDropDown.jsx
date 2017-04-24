import React, { Component } from 'react'
var LanguageDropDown = (props) => {

    return (
        <ul className="header-dropdown-list hidden-xs">
            <li>
                <a href="#" className="dropdown-toggle" data-toggle="dropdown"> <img src="img/blank.gif" className="flag flag-us" alt="United States" /> <span> English (US) </span> <i className="fa fa-angle-down"></i> </a>
                <ul className="dropdown-menu pull-right">
                    <li className="active">
                        <a href="javascript:void(0);"><img src="img/blank.gif" className="flag flag-us" alt="United States" /> English (US)</a>
                    </li>
                    <li>
                        <a href="javascript:void(0);"><img src="img/blank.gif" className="flag flag-fr" alt="France" /> Français</a>
                    </li>
                    <li>
                        <a href="javascript:void(0);"><img src="img/blank.gif" className="flag flag-es" alt="Spanish" /> Español</a>
                    </li>
                    <li>
                        <a href="javascript:void(0);"><img src="img/blank.gif" className="flag flag-de" alt="German" /> Deutsch</a>
                    </li>
                    <li>
                        <a href="javascript:void(0);"><img src="img/blank.gif" className="flag flag-jp" alt="Japan" /> 日本語</a>
                    </li>
                    <li>
                        <a href="javascript:void(0);"><img src="img/blank.gif" className="flag flag-cn" alt="China" /> 中文</a>
                    </li>
                    <li>
                        <a href="javascript:void(0);"><img src="img/blank.gif" className="flag flag-it" alt="Italy" /> Italiano</a>
                    </li>
                    <li>
                        <a href="javascript:void(0);"><img src="img/blank.gif" className="flag flag-pt" alt="Portugal" /> Portugal</a>
                    </li>
                    <li>
                        <a href="javascript:void(0);"><img src="img/blank.gif" className="flag flag-ru" alt="Russia" /> Русский язык</a>
                    </li>
                    <li>
                        <a href="javascript:void(0);"><img src="img/blank.gif" className="flag flag-kr" alt="Korea" /> 한국어</a>
                    </li>

                </ul>
            </li>
        </ul>

    );
};
export default LanguageDropDown;