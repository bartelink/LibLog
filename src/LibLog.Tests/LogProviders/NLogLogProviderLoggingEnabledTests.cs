﻿using System;
using NLog;
using NLog.Config;
using NLog.Targets;
using Xunit;

namespace DH.Logging.LogProviders
{
    public class NLogLogProviderLoggingEnabledTests : IDisposable
    {
        private readonly ILog _sut;
        private readonly MemoryTarget _target;

        public NLogLogProviderLoggingEnabledTests()
        {
            var config = new LoggingConfiguration();
            _target = new MemoryTarget();
            _target.Layout = "${level:uppercase=true}|${message}|${exception}";
            config.AddTarget("memory", _target);
            config.LoggingRules.Add(new LoggingRule("*", NLog.LogLevel.Trace, _target));
            LogManager.Configuration = config;
            _sut = new NLogLogProvider().GetLogger("Test");
        }

        public void Dispose()
        {
            LogManager.Configuration = null;
        }

        [Fact]
        public void Should_be_able_to_log_debug_exception()
        {
            _sut.Log(LogLevel.Debug, () => "m", new Exception("e"));
            Assert.NotEmpty(_target.Logs);
            Assert.Equal("DEBUG|m|e", _target.Logs[0]);
        }

        [Fact]
        public void Should_be_able_to_log_debug_message()
        {
            _sut.Log(LogLevel.Debug, () => "m");
            Assert.NotEmpty(_target.Logs);
            Assert.Equal("DEBUG|m|", _target.Logs[0]);
        }

        [Fact]
        public void Should_be_able_to_log_error_exception()
        {
            _sut.Log(LogLevel.Error, () => "m", new Exception("e"));
            Assert.NotEmpty(_target.Logs);
            Assert.Equal("ERROR|m|e", _target.Logs[0]);
        }

        [Fact]
        public void Should_be_able_to_log_error_message()
        {
            _sut.Log(LogLevel.Error, () => "m");
            Assert.NotEmpty(_target.Logs);
            Assert.Equal("ERROR|m|", _target.Logs[0]);
        }

        [Fact]
        public void Should_be_able_to_log_fatal_exception()
        {
            _sut.Log(LogLevel.Fatal, () => "m", new Exception("e"));
            Assert.NotEmpty(_target.Logs);
            Assert.Equal("FATAL|m|e", _target.Logs[0]);
        }

        [Fact]
        public void Should_be_able_to_log_fatal_message()
        {
            _sut.Log(LogLevel.Fatal, () => "m");
            Assert.NotEmpty(_target.Logs);
            Assert.Equal("FATAL|m|", _target.Logs[0]);
        }

        [Fact]
        public void Should_be_able_to_log_info_exception()
        {
            _sut.Log(LogLevel.Info, () => "m", new Exception("e"));
            Assert.NotEmpty(_target.Logs);
            Assert.Equal("INFO|m|e", _target.Logs[0]);
        }

        [Fact]
        public void Should_be_able_to_log_info_message()
        {
            _sut.Log(LogLevel.Info, () => "m");
            Assert.NotEmpty(_target.Logs);
            Assert.Equal("INFO|m|", _target.Logs[0]);
        }

        [Fact]
        public void Should_be_able_to_log_trace_exception()
        {
            _sut.Log(LogLevel.Trace, () => "m", new Exception("e"));
            Assert.NotEmpty(_target.Logs);
            Assert.Equal("TRACE|m|e", _target.Logs[0]);
        }

        [Fact]
        public void Should_be_able_to_log_trace_message()
        {
            _sut.Log(LogLevel.Trace, () => "m");
            Assert.NotEmpty(_target.Logs);
            Assert.Equal("TRACE|m|", _target.Logs[0]);
        }

        [Fact]
        public void Should_be_able_to_log_warn_exception()
        {
            _sut.Log(LogLevel.Warn, () => "m", new Exception("e"));
            Assert.NotEmpty(_target.Logs);
            Assert.Equal("WARN|m|e", _target.Logs[0]);
        }

        [Fact]
        public void Should_be_able_to_log_warn_message()
        {
            _sut.Log(LogLevel.Warn, () => "m");
            Assert.NotEmpty(_target.Logs);
            Assert.Equal("WARN|m|", _target.Logs[0]);
        }
    }
}