import React, {Component} from 'react'
var UserInfo = (props) => {
    return (
			<div className="login-info">
				<span> 				
					<a href="javascript:void(0);" id="show-shortcut" data-action="toggleShortcut">
						<img src="img/avatars/sunny.png" alt="me" className="online" /> 
						<span>
							john.doe 
						</span>
					</a> 				
				</span>
			</div>
    );
};
export default UserInfo;