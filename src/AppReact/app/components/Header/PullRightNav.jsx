import React, { Component } from 'react'
import SearchBox from 'SearchBox'
// import FullScreenButton from 'FullScreenButton'
// import SpeechButton from 'SpeechButton'
// import LanguageDropDown from 'LanguageDropDown'
// import LogOutButton from 'LogOutButton'
import ToggleMenu from 'ToggleMenu'
// import LocationButton from 'LocationButton'
var PullRightNav = (props) => {

	return (
		<div className="pull-right">
			<ToggleMenu />
			{/*<LogOutButton />*/}
			<div id="search-mobile" className="btn-header transparent pull-right">
				<span> <a href="javascript:void(0)" title="Search"><i className="fa fa-search"></i></a> </span>
			</div>
			<SearchBox />
			{/*<LocationButton />*/}
			{/*<FullScreenButton />*/}
			{/*<SpeechButton />*/}
			{/*<LanguageDropDown />*/}

		</div>
	);

};
export default PullRightNav;