import chai from 'chai';
import chaiAsPromised from 'chai-as-promised';

chai.use(chaiAsPromised);

process.env.NODE_ENV = 'test';
process.env.port = 8081;
