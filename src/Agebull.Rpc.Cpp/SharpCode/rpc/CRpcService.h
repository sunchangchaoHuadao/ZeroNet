#ifndef AGEBULL_RPC_H
#pragma once
#include "stdafx.h"

class CRpcService
{
public:
	/**
	* \brief ��ʼ��
	*/
	static void Initialize()
	{
		// �ڳ����ʼ��ʱ����־
		acl::acl_cpp_init();
		string path;
		GetProcessFilePath(path);
		auto log = path;
		log.append(".log");
		logger_open(log.c_str(), "mq_server", DEBUG_CONFIG);
		log_acl_msg("Initialize");
	}

	/**
	* \brief
	*/
	static void Start()
	{
		log_acl_msg("Start");
		// ���������Լ��ĳ�ʼ������...
		init_net_command();
		start_net_command();
	}

	/**
	* \brief ��ֹ
	*/
	static void Stop()
	{
		log_acl_msg("Stop");
		//���������
		distory_net_command();
		acl::log::close();
		thread_sleep(1000);
	}
};
#endif AGEBULL_RPC_H