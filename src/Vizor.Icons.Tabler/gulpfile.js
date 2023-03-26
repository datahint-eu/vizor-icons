// Following steps are required to install gulp: see https://gulpjs.com/docs/en/getting-started/quick-start/
// npm install --global gulp-cli
//
// in the project dir:
//   npm init
//   npm install --save-dev gulp child_process
//   npm install @tabler/icons
//
// to build:
//   gulp

var gulp = require('gulp');
var path = require('path');
var exec = require("child_process").exec;

gulp.task("publishLocal", function (callback) {
	exec(
		"Powershell.exe -executionpolicy remotesigned . .\\publish_local.ps1 -Push:1",
		function (err, stdout, stderr) {
			console.log(stdout);
			callback(err);
		}
	);
});