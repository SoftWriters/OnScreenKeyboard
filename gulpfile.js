const babel = require('gulp-babel');
const gulp = require('gulp');
const nodemon = require('gulp-nodemon');

gulp.task('compile', () => {
  return gulp.src('src/**/*')
    .pipe(babel({
      presets: ['es2015']
    }))
    .pipe(gulp.dest('dist'));
});

gulp.task('server', ['compile'], () => {
  const server = nodemon({
    env: { NODE_ENV: 'development' },
    script: 'dist/server/main.js',
    tasks: ['compile'],
    watch: 'src/server'
  });
  return server;
});

gulp.task('default', ['server']);
