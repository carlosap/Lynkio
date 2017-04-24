var webpack = require('webpack');
module.exports = {
  entry: [
    './app/app.jsx'
  ],
  output: {
    path: __dirname,
    filename: './public/bundle.js'
  },
  resolve: {
    root: __dirname,
    alias: {
      Main: 'app/components/Main.jsx',
      ActivityTool: 'app/components/Footer/ActivityTool.jsx',
      CopyRight: 'app/components/Footer/CopyRight.jsx',
      Footer: 'app/components/Footer/Footer.jsx',
      LogoGroup: 'app/components/Header/LogoGroup.jsx',
      ProjectsDropDown: 'app/components/Header/ProjectsDropDown.jsx',
      SearchBox: 'app/components/Header/SearchBox.jsx',
      FullScreenButton: 'app/components/Header/FullScreenButton.jsx',
      SpeechButton: 'app/components/Header/SpeechButton.jsx',
      LanguageDropDown: 'app/components/Header/LanguageDropDown.jsx',
      LogOutButton: 'app/components/Header/LogOutButton.jsx',
      LocationButton: 'app/components/Header/LocationButton.jsx',
      ToggleMenu: 'app/components/Header/ToggleMenu.jsx',
      PullRightNav: 'app/components/Header/PullRightNav.jsx',
      Header: 'app/components/Header/Header.jsx',
      Nav: 'app/components/LeftPanel/Nav.jsx',
      UserInfo: 'app/components/LeftPanel/UserInfo.jsx',
      LeftPanel: 'app/components/LeftPanel/LeftPanel.jsx',
      BreadCrumb: 'app/components/Ribbon/BreadCrumb.jsx',
      RefreshButton: 'app/components/Ribbon/RefreshButton.jsx',
      Ribbon: 'app/components/Ribbon/Ribbon.jsx',
      DashboardSection: 'app/components/Pages/Dashboard/DashboardSection.jsx',
      Dashboard: 'app/components/Pages/Dashboard/Dashboard.jsx',

    },
    extensions: ['', '.js', '.jsx']
  },
  module: {
    loaders: [
      { 
        test: /\.jsx$/,
        loader: 'babel-loader',
        query: {
          presets: ['react', 'es2015','stage-0']
        },
        exclude: /(node_modules|bower_components)/ 
      }
    ]
  },
  //allows you to debug via browser module.
  devtool: 'cheap-module-eval-source-map'
};
