// Following steps are required to install gulp: see https://gulpjs.com/docs/en/getting-started/quick-start/
// npm install --global gulp-cli
//
// in the project dir:
//   npm init
//   npm install --save-dev gulp gulp-clean
//   npm install @tabler/icons
//
// to build:
//   gulp

var path = require('path'),
	clean = require('gulp-clean'),
	gulp = require('gulp');

var wwwroot = path.resolve(__dirname, "wwwroot");
var libroot = path.resolve(__dirname, "./node_modules");


var srcPaths = {
	css: [
		path.resolve(libroot, '@tabler/icons/iconfont/tabler-icons.min.css')
	],

	fonts: [
		path.resolve(libroot, '@tabler/icons/iconfont/fonts/tabler-icons.woff2'),
		path.resolve(libroot, '@tabler/icons/iconfont/fonts/tabler-icons.ttf'),
		path.resolve(libroot, '@tabler/icons/iconfont/fonts/tabler-icons.woff'),
		path.resolve(libroot, '@tabler/icons/iconfont/fonts/tabler-icons.eot'),
		path.resolve(libroot, '@tabler/icons/iconfont/fonts/tabler-icons.svg')
	]
};


var destPaths = {
	css: path.resolve(wwwroot, 'css'),
	fonts: path.resolve(wwwroot, 'css/fonts')
};


gulp.task('clean', () => {
	return gulp.src(
		[path.resolve(wwwroot, 'css/**'), path.resolve(wwwroot, 'js/**'), path.resolve(wwwroot, 'lib/**')])
		.pipe(clean());
});

gulp.task('css', () => {
	return gulp.src(srcPaths.css)
		.pipe(gulp.dest(destPaths.css));
});

gulp.task('fonts', () => {
	return gulp.src(srcPaths.fonts)
		.pipe(gulp.dest(destPaths.fonts));
});

gulp.task('cleanup', gulp.series(['clean']));
gulp.task('default', gulp.series(['css'], ['fonts']));